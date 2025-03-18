using DRR.Application.Contracts.Commands.Specialists;
using DRR.Application.Contracts.Queries.Specialists;
using DRR.Application.Contracts.Repository.Specialists;
using DRR.Application.Contracts.Services.Specialists;
using DRR.Framework.Contracts.Markers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DRR.Application.QueryHandlers.Specialists
{
    public class ReadCategoryQueryHandler : IQueryHandler<ReadCategoryQuery, ReadCategoryQueryResponse>
    {
        private readonly ICategorysRepository _categoryRepository;
        private readonly ISpecialistCategorysRepository _specialistCategoryRepository;

        public ReadCategoryQueryHandler(ICategorysRepository categoryRepository, ISpecialistCategorysRepository specialistCategoryRepository)
        {
            _categoryRepository = categoryRepository;
            _specialistCategoryRepository = specialistCategoryRepository;
        }

        public async Task<ReadCategoryQueryResponse> Execute(ReadCategoryQuery query, CancellationToken cancellationToken)
        {

            var category = await _categoryRepository.ReadCategoryById(query.Id);
            var specialists = await _specialistCategoryRepository.ReadSpecialistsByCategoryId(query.Id);

            var scd = new SpecialistCategoryDto()
            {
                CategoryName = category.CategoryName,
                Specialists = specialists
            };
            var result = new ReadCategoryQueryResponse
            {
                Data = scd
            };

            return result;
        }
    }
}