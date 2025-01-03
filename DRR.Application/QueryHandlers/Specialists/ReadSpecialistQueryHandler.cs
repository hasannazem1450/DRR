using DRR.Application.Contracts.Queries.Event;
using DRR.Application.Contracts.Queries.Specialists;
using DRR.Application.Contracts.Repository.Event;
using DRR.Application.Contracts.Repository.Specialists;
using DRR.Application.Contracts.Services.Event;
using DRR.Application.Contracts.Services.Specialists;
using DRR.Application.Services.Event;
using DRR.CommandDb.Repository.Event;
using DRR.Framework.Contracts.Markers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DRR.Application.QueryHandlers.Specialists
{
    public class ReadSpecialistQueryHandler : IQueryHandler<ReadSpecialistQuery, ReadSpecialistQueryResponse>
    {
        private readonly ISpecialistRepository _specialistRepository;
        private readonly ISpecialistService _specialistService;

        public ReadSpecialistQueryHandler(ISpecialistRepository specialistRepository, ISpecialistService specialistService)
        {
            _specialistRepository = specialistRepository;
            _specialistService = specialistService;
        }

        public async Task<ReadSpecialistQueryResponse> Execute(ReadSpecialistQuery query, CancellationToken cancellationToken)
        {

            var specialist = await _specialistRepository.ReadSpecialistById(query.SpecialistId);

            var result = new ReadSpecialistQueryResponse
            {
                Data = await _specialistService.ConvertToDto(specialist)
            };

            return result;
        }
    }
}