using DRR.Application.CommandHandlers.Specialists.Exceptions;
using DRR.Application.Contracts.Commands.Specialists;
using DRR.Application.Contracts.Repository.Specialists;
using DRR.Application.Contracts.Services.Specialists;
using DRR.Framework.Contracts.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.CommandHandlers.Specialists
{
    public class UpdateCategoryCommandHandler : CommandHandler<UpdateCategoryCommand, UpdateCategoryCommandResponse>
    {
        private readonly ICategorysRepository _categorysRepository;
        private readonly ISpecialistService _specialistService;

        public UpdateCategoryCommandHandler(ICategorysRepository categorysRepository, ISpecialistService specialistService)
        {
            _categorysRepository = categorysRepository;
            _specialistService = specialistService;
        }
        public override async Task<UpdateCategoryCommandResponse> Executor(UpdateCategoryCommand command)
        {
            var size = await _specialistService.GetFileSizeKb(command.CategoryLogoFile);
            if (size < 30)
            {
                var c = await _categorysRepository.ReadCategoryById(command.Id);

                c.Update(command.CategoryName, command.CategoryLogoFile);

                await _categorysRepository.Update(c);
            }
            else
            {
                throw new SpecialistException();
            }

            return new UpdateCategoryCommandResponse();
        }
    }
}
