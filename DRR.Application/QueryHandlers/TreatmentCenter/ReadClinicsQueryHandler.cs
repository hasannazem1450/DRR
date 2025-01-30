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
    public class ReadClinicsQueryHandler : IQueryHandler<ReadClinicsQuery, ReadClinicsQueryResponse>
    {
        private readonly IClinicRepository _clinicRepository;
        private readonly IClinicService _clinicService;

        public ReadClinicsQueryHandler(IClinicRepository clinicRepository, IClinicService clinicService)
        {
            _clinicRepository = clinicRepository;
            _clinicService = clinicService;
        }

        public async Task<ReadClinicsQueryResponse> Execute(ReadClinicsQuery query, CancellationToken cancellationToken)
        {
            var clinics = await _clinicRepository.ReadClinics();

            var result = new ReadClinicsQueryResponse
            {
                List = await _clinicService.ConvertToDto(clinics)
            };

            return result;
        }
    }
}