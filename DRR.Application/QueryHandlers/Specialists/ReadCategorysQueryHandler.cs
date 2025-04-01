using DRR.Application.Contracts.Commands.Specialists;
using DRR.Application.Contracts.Queries.Specialists;
using DRR.Application.Contracts.Repository.Specialists;
using DRR.Domain.Specialists;
using DRR.Framework.Contracts.Markers;
using DRR.Utilities.Extensions;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DRR.Application.QueryHandlers.Specialists
{
    public class ReadCategorysQueryHandler : IQueryHandler<ReadCategorysQuery, ReadCategorysQueryResponse>
    {
        private readonly ICategorysRepository _categoryRepository;
        private readonly ISpecialistCategorysRepository _specialistCategoryRepository;

        public ReadCategorysQueryHandler(ICategorysRepository categoryRepository, ISpecialistCategorysRepository specialistCategoryRepository)
        {
            _categoryRepository = categoryRepository;
            _specialistCategoryRepository = specialistCategoryRepository;
        }

        public async Task<ReadCategorysQueryResponse> Execute(ReadCategorysQuery query, CancellationToken cancellationToken)
        {

            var categorys = await _categoryRepository.ReadCategorys();
            var specialists = new List<Specialist>();
            List<SpecialistCategoryDto> res = new List<SpecialistCategoryDto>();
            foreach (var item in categorys)
            {
                specialists = await _specialistCategoryRepository.ReadSpecialistsByCategoryId(item.Id);
                var scd = new SpecialistCategoryDto()
                {
                    Id= item.Id,
                    CategoryName = item.CategoryName,
                    CategoryLogoFile = item.CategoryLogoFile,
                    Specialists = specialists
                };
                res.Add(scd);
            }

            var result = new ReadCategorysQueryResponse
            {
                List = res
            };

            return result;
        }
    }
}