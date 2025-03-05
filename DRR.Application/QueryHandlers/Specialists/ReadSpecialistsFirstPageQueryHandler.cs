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
    public class ReadSpecialistsFirstPageQueryHandler : IQueryHandler<ReadSpecialistsFirstPageQuery, ReadSpecialistsFirstPageQueryResponse>
    {
        private readonly ISpecialistRepository _specialistRepository;
        private readonly ISpecialistService _specialistService;

        public ReadSpecialistsFirstPageQueryHandler(ISpecialistRepository specialistRepository, ISpecialistService specialistService)
        {
            _specialistRepository = specialistRepository;
            _specialistService = specialistService;
        }

        public async Task<ReadSpecialistsFirstPageQueryResponse> Execute(ReadSpecialistsFirstPageQuery query, CancellationToken cancellationToken)
        {
            var sps = await _specialistRepository.ReadSpecialists();

            var result = new ReadSpecialistsFirstPageQueryResponse
            {
                List = await _specialistService.ConvertToDto(sps)
            };

            return result;
        }
    }
}