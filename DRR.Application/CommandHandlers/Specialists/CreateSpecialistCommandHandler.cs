using DRR.Application.Contracts.Commands.Event;
using DRR.Application.Contracts.Commands.Specialists;
using DRR.Application.Contracts.Repository.Event;
using DRR.Application.Contracts.Repository.Specialists;
using DRR.Framework.Contracts.Abstracts;
using System.Threading.Tasks;

namespace DRR.Application.CommandHandlers.Specialists
{
    public class CreateSpecialistCommandHandler : CommandHandler<CreateSpecialistCommand, CreateSpecialistCommandResponse>
    {
        private readonly ISpecialistRepository _specialistRepository;


        public CreateSpecialistCommandHandler(ISpecialistRepository specialistRepository)
        {
            _specialistRepository = specialistRepository;
        }
        public override async Task<CreateSpecialistCommandResponse> Executor(CreateSpecialistCommand command)
        {
            var sp = new Domain.Specialists.Specialist(command.Name);

            await _specialistRepository.Create(sp);

            return new CreateSpecialistCommandResponse();
        }
    }
}
