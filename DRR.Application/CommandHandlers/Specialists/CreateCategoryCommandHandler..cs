using DRR.Application.CommandHandlers.Specialists.Exceptions;
using DRR.Application.Contracts.Commands.Specialists;
using DRR.Application.Contracts.Repository.Specialists;
using DRR.Application.Contracts.Services.Specialists;
using DRR.CommandDb.Repository.Specialists;
using DRR.Domain.Specialists;
using DRR.Framework.Contracts.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.CommandHandlers.Specialists
{
    public class CreateCategoryCommandHandler : CommandHandler<CreateCategoryCommand, CreateCategoryCommandResponse>
    {
        private readonly ICategorysRepository _categorysRepository;
        private readonly ISpecialistCategorysService _specialistCategoryService;


        public CreateCategoryCommandHandler(ICategorysRepository categorysRepository, ISpecialistCategorysService specialistCategoryService)
        {
            _categorysRepository = categorysRepository;
            _specialistCategoryService = specialistCategoryService;
        }
        public override async Task<CreateCategoryCommandResponse> Executor(CreateCategoryCommand command)
        {
            var cats = await _categorysRepository.ReadCategorys();
            if (cats != null && cats.Where(x => x.CategoryName == command.CategoryName).Count() > 0)
                throw new Exception("نام دسته بندی تکراری است");
            var size = await _specialistCategoryService.GetFileSizeKb(command.CategoryLogoFile);
            if (size < 30)
            {
                var sp = new Category(command.CategoryName, command.CategoryLogoFile);

                await _categorysRepository.Create(sp);
            }
            else
            {
                throw new Exception("حجم فایل عکس لوگو بیشتر از 30 کیلو بایت است");
            }


            return new CreateCategoryCommandResponse();
        }
    }
}
