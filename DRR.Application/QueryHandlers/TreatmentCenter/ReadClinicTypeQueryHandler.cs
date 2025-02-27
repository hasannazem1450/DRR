﻿using DRR.Application.Contracts.Queries.TreatmentCenter;
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
    public class ReadClinicTypeQueryHandler : IQueryHandler<ReadClinicTypeQuery, ReadClinicTypeQueryResponse>
    {
        private readonly IClinicTypeRepository _clinicTypeRepository;
        private readonly IClinicTypeService _clinicTypeService;

        public ReadClinicTypeQueryHandler(IClinicTypeRepository clinicTypeRepository, IClinicTypeService clinicTpeService)
        {
            _clinicTypeRepository = clinicTypeRepository;
            _clinicTypeService = clinicTpeService;
        }

        public async Task<ReadClinicTypeQueryResponse> Execute(ReadClinicTypeQuery query, CancellationToken cancellationToken)
        {
            var clinicType = await _clinicTypeRepository.ReadClinicTypeById(query.Id);

            var result = new ReadClinicTypeQueryResponse
            {
                Data = await _clinicTypeService.ConvertToDto(clinicType)
            };

            return result;
        }
    }
}
