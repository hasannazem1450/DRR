using DRR.Application.Contracts.Commands.Profile.FollowProfile;
using DRR.Application.Contracts.Commands.TreatmentCenters;
using DRR.Application.Contracts.Queries.Event;
using DRR.Application.Contracts.Queries.Profile.FollowProfile;
using DRR.Application.Contracts.Queries.TreatmentCenter;
using DRR.Application.Contracts.Repository.Event;
using DRR.Application.Contracts.Repository.TreatmentCenters;
using DRR.Application.Contracts.Services.Event;
using DRR.Application.Contracts.Services.TraetmentCenter;
using DRR.Domain.Profile.Follow;
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
            var doctorsCount = 0;


            var result = new ReadClinicsQueryResponse();

            foreach (var item in clinics)
            {
                doctorsCount = await _clinicRepository.ReadClinicDoctorsCountById(item.Id);
                var dto = await _clinicService.ConvertToDto(item, doctorsCount);


                result.List.Add(dto);
            }

            return result;
        }
    }
}