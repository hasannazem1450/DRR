using DRR.Application.Contracts.Commands.Event;
using DRR.Application.Contracts.Commands.Specialists;
using DRR.Application.Contracts.Repository.Event;
using DRR.Application.Contracts.Repository.Specialists;
using DRR.Framework.Contracts.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.CommandHandlers.Specialists
{
    public class DeleteSpecialistCommandHandler : CommandHandler<DeleteSpecialistCommand, DeleteSpecialistCommandResponse>
    {

        private readonly ISpecialistRepository _specialistRepository;


        public DeleteSpecialistCommandHandler(ISpecialistRepository specialistRepository)
        {
            _specialistRepository = specialistRepository;
        }

        public override async Task<DeleteSpecialistCommandResponse> Executor(DeleteSpecialistCommand command)
        {
            await _specialistRepository.Delete(command.Id);

            return new DeleteSpecialistCommandResponse();
        }
    }
}
