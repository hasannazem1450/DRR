using DRR.Application.Contracts.Queries.Customer;
using DRR.Application.Contracts.Queries.TreatmentCenter;
using DRR.Application.Contracts.Repository.Customer;
using DRR.Application.Contracts.Repository.TreatmentCenters;
using DRR.Application.Contracts.Services.Customer;
using DRR.Application.Contracts.Services.TraetmentCenter;
using DRR.Framework.Contracts.Markers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DRR.Application.QueryHandlers.Customer
{
    public class ReadDoctorsInTreatmentCenterQueryHandler : IQueryHandler<ReadDoctorsInTreatmentCenterQuery, ReadDoctorsInTreatmentCenterQueryResponse>
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly IDoctorService _doctorService;
        public ReadDoctorsInTreatmentCenterQueryHandler(IDoctorRepository doctorRepository, IDoctorService doctorService)
        {
            _doctorRepository = doctorRepository;
            _doctorService = doctorService;
        }

        public async Task<ReadDoctorsInTreatmentCenterQueryResponse> Execute(ReadDoctorsInTreatmentCenterQuery query, CancellationToken cancellationToken)
        {
            var dtc = await _doctorRepository.ReadDoctorsByTreatmentCenterId(query.TreatmentCenterId);

            var result = new ReadDoctorsInTreatmentCenterQueryResponse
            {
                List = await _doctorService.ConvertToBoxDto(dtc)
            };

            return result;
        }

    }
}