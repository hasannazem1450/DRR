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
    public class ReadOfficeTypesQueryHandler : IQueryHandler<ReadOfficeTypesQuery, ReadOfficeTypesQueryResponse>
    {
        private readonly IOfficeTypeRepository _officeTypeRepository;
        private readonly IOfficeTypeService _officeTypeService;

        public ReadOfficeTypesQueryHandler(IOfficeTypeRepository officeTypeRepository, IOfficeTypeService officeTypeService)
        {
            _officeTypeRepository = officeTypeRepository;
            _officeTypeService = officeTypeService;
        }

        public async Task<ReadOfficeTypesQueryResponse> Execute(ReadOfficeTypesQuery query, CancellationToken cancellationToken)
        {
            var officeTypes = await _officeTypeRepository.ReadOfficeTypes();

            var result = new ReadOfficeTypesQueryResponse
            {
                List = await _officeTypeService.ConvertToDto(officeTypes)
            };

            return result;
        }
    }
}