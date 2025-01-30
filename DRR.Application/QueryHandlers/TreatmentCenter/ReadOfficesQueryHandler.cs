using DRR.Application.Contracts.Queries.Event;
using DRR.Application.Contracts.Queries.TreatmentCenter;
using DRR.Application.Contracts.Repository.Event;
using DRR.Application.Contracts.Repository.TreatmentCenters;
using DRR.Application.Contracts.Services.Event;
using DRR.Application.Contracts.Services.TraetmentCenter;
using DRR.Framework.Contracts.Markers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DRR.Application.QueryHandlers.TreatmentCenter
{
    public class ReadOfficesQueryHandler : IQueryHandler<ReadOfficesQuery, ReadOfficesQueryResponse>
    {
        private readonly IOfficeRepository _officeRepository;
        private readonly IOfficeService _officeService;

        public ReadOfficesQueryHandler(IOfficeRepository officeRepository, IOfficeService officeService)
        {
            _officeRepository = officeRepository;
            _officeService = officeService;
        }

        public async Task<ReadOfficesQueryResponse> Execute(ReadOfficesQuery query, CancellationToken cancellationToken)
        {
            var offices = await _officeRepository.ReadOffices();

            var result = new ReadOfficesQueryResponse
            {
                List = await _officeService.ConvertToDto(offices)
            };

            return result;
        }
    }
}