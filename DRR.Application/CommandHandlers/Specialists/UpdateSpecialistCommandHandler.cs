using DRR.Application.CommandHandlers.Specialists.Exceptions;
using DRR.Application.Contracts.Commands.Event;
using DRR.Application.Contracts.Commands.Specialists;
using DRR.Application.Contracts.Repository.Specialists;
using DRR.Application.Contracts.Services.Specialists;
using DRR.Application.Services.Specialists;
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
        private readonly ISpecialistService _specialistService;

        public UpdateSpecialistCommandHandler(ISpecialistRepository specialistRepository, ISpecialistService specialistService)
        {
            _specialistRepository = specialistRepository;
            _specialistService = specialistService;
        }
        public override async Task<UpdateSpecialistCommandResponse> Executor(UpdateSpecialistCommand command)
        {
            var size = await _specialistService.GetFileSizeKb(command.LogoFile);
            if (size < 30)
            {
                var sp = await _specialistRepository.ReadSpecialistById(command.Id);

                sp.Update(command.Name,command.Maxa,command.MaxaName, command.LogoFile);

                await _specialistRepository.Update(sp);
            }
            else
            {
                throw new SpecialistException();
            }

            return new UpdateSpecialistCommandResponse();
        }
    }
}
