using DRR.Application.Contracts.Queries.TreatmentCenter;
using DRR.Application.Contracts.Repository.TreatmentCenters;
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
    public class ReadOfficeQueryHandler : IQueryHandler<ReadOfficeQuery, ReadOfficeQueryResponse>
    {
        private readonly IOfficeRepository _officeRepository;
        private readonly IOfficeService _officeService;

        public ReadOfficeQueryHandler(IOfficeRepository officeRepository, IOfficeService officeService)
        {
            _officeRepository = officeRepository;
            _officeService = officeService;
        }

        public async Task<ReadOfficeQueryResponse> Execute(ReadOfficeQuery query, CancellationToken cancellationToken)
        {
            var office = await _officeRepository.ReadOfficeById(query.Id);

            var result = new ReadOfficeQueryResponse
            {
                Data = await _officeService.ConvertToDto(office)
            };

            return result;
        }
    }
}