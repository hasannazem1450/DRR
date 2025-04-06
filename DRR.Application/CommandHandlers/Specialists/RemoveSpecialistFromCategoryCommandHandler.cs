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
    public class RemoveSpecialistFromCategoryCommandHandler : CommandHandler<RemoveSpecialistFromCategoryCommand, RemoveSpecialistFromCategoryCommandResponse>
    {

        private readonly ISpecialistCategorysRepository _specialistCaterysRepository;


        public RemoveSpecialistFromCategoryCommandHandler(ISpecialistCategorysRepository specialistCaterysRepository)
        {
            _specialistCaterysRepository = specialistCaterysRepository;
        }

        public override async Task<RemoveSpecialistFromCategoryCommandResponse> Executor(RemoveSpecialistFromCategoryCommand command)
        {
            await _specialistCaterysRepository.Delete(command.SpecialistId, command.CategoryId);

            return new RemoveSpecialistFromCategoryCommandResponse();
        }
    }
}
