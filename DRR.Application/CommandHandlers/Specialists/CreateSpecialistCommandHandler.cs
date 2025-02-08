using DRR.Application.CommandHandlers.Exceptions;
using DRR.Application.CommandHandlers.Specialists.Exceptions;
using DRR.Application.Contracts.Commands.Event;
using DRR.Application.Contracts.Commands.Specialists;
using DRR.Application.Contracts.Repository.Event;
using DRR.Application.Contracts.Repository.Specialists;
using DRR.Application.Contracts.Services.FileManagment;
using DRR.Application.Contracts.Services.Specialists;
using DRR.Application.Services.FileManagment;
using DRR.Domain.Specialists;
using DRR.Framework.Contracts.Abstracts;
using System.Threading.Tasks;

namespace DRR.Application.CommandHandlers.Specialists
{
    public class CreateSpecialistCommandHandler : CommandHandler<CreateSpecialistCommand, CreateSpecialistCommandResponse>
    {
        private readonly ISpecialistRepository _specialistRepository;
        private readonly ISpecialistService _specialistService;


        public CreateSpecialistCommandHandler(ISpecialistRepository specialistRepository , ISpecialistService specialistService)
        {
            _specialistRepository = specialistRepository;
            _specialistService = specialistService;
        }
        public override async Task<CreateSpecialistCommandResponse> Executor(CreateSpecialistCommand command)
        {
            var size = await _specialistService.GetFileSizeKb(command.LogoFile);
            if (size < 30)
            {
                var sp = new Specialist(command.Name ,command.Maxa, command.MaxaName ,command.LogoFile);

                await _specialistRepository.Create(sp);
            }
            else
            {
                throw new SpecialistException();
            }


            return new CreateSpecialistCommandResponse();
        }
    }
}
