using DRR.Application.Contracts.Queries.Event;
using DRR.Application.Contracts.Queries.TreatmentCenter;
using DRR.Application.Contracts.Repository.Event;
using DRR.Application.Contracts.Repository.TreatmentCenters;
using DRR.Application.Contracts.Services.Event;
using DRR.Application.Contracts.Services.TraetmentCenter;
using DRR.Domain.TreatmentCenters;
using DRR.Framework.Contracts.Markers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DRR.Application.QueryHandlers.TreatmentCenter
{
    public class ReadClinicQueryHandler : IQueryHandler<ReadClinicQuery, ReadClinicQueryResponse>
    {
        private readonly IClinicRepository _clinicRepository;
        private readonly IClinicService _clinicService;

        public ReadClinicQueryHandler(IClinicRepository clinicRepository, IClinicService clinicService)
        {
            _clinicRepository = clinicRepository;
            _clinicService = clinicService;
        }

        public async Task<ReadClinicQueryResponse> Execute(ReadClinicQuery query, CancellationToken cancellationToken)
        {
            var clinic = await _clinicRepository.ReadClinicById(query.Id);
            var doctorsCount = await _clinicRepository.ReadClinicDoctorsCountById(clinic.Id);
            var result = new ReadClinicQueryResponse
            {
                Data = await _clinicService.ConvertToDto(clinic, doctorsCount)
            };

            return result;
        }
    }
}