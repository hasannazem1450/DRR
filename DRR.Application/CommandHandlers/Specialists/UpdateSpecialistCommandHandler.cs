using DRR.Application.Contracts.Commands.Event;
using DRR.Application.Contracts.Commands.Specialists;
using DRR.Application.Contracts.Repository.Specialists;
using DRR.Framework.Contracts.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.CommandHandlers.Specialists
{
    public class UpdateSpecialistCommandHandler : CommandHandler<UpdateSpecialistCommand, UpdateSpecialistCommandResponse>
    {
        private readonly ISpecialistRepository _specialistRepository;


        public UpdateSpecialistCommandHandler(ISpecialistRepository specialistRepository)
        {
            _specialistRepository = specialistRepository;
        }
        public override async Task<UpdateSpecialistCommandResponse> Executor(UpdateSpecialistCommand command)
        {
            var sp = await _specialistRepository.ReadSpecialistById(command.Id);

            sp.Update(command.Name);

            await _specialistRepository.Update(sp);

            return new UpdateSpecialistCommandResponse();
        }
    }
}
