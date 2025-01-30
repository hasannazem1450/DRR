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
    public class ReadOfficeTyprQueryHandler : IQueryHandler<ReadOfficeTypeQuery, ReadOfficeTypeQueryResponse>
    {
        private readonly IOfficeTypeRepository _officeTypeRepository;
        private readonly IOfficeTypeService _officeTypeService;

        public ReadOfficeTyprQueryHandler(IOfficeTypeRepository officeTypeRepository, IOfficeTypeService officeTypeService)
        {
            _officeTypeRepository = officeTypeRepository;
            _officeTypeService = officeTypeService;
        }

        public async Task<ReadOfficeTypeQueryResponse> Execute(ReadOfficeTypeQuery query, CancellationToken cancellationToken)
        {
            var officeType = await _officeTypeRepository.ReadOfficeTypeById(query.Id);

            var result = new ReadOfficeTypeQueryResponse
            {
                Data = await _officeTypeService.ConvertToDto(officeType)
            };

            return result;
        }
    }
}