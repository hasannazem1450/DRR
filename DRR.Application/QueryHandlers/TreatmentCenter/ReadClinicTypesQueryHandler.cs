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
    public class ReadClinicTypesQueryHandler : IQueryHandler<ReadClinicTypesQuery, ReadClinicTypesQueryResponse>
    {
        private readonly IClinicTypeRepository _clinicTypeRepository;
        private readonly IClinicTypeService _clinicTypeService;

        public ReadClinicTypesQueryHandler(IClinicTypeRepository clinicTypeRepository, IClinicTypeService clinicTypeService)
        {
            _clinicTypeRepository = clinicTypeRepository;
            _clinicTypeService = clinicTypeService;
        }

        public async Task<ReadClinicTypesQueryResponse> Execute(ReadClinicTypesQuery query, CancellationToken cancellationToken)
        {
            var clinicTypes = await _clinicTypeRepository.ReadClinicTypes();

            var result = new ReadClinicTypesQueryResponse
            {
                List = await _clinicTypeService.ConvertToDto(clinicTypes)
            };

            return result;
        }
    }
}
