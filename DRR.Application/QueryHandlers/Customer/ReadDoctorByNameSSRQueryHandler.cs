using DRR.Application.Contracts.Queries.Customer;
using DRR.Application.Contracts.Queries.TreatmentCenter;
using DRR.Application.Contracts.Repository.Customer;
using DRR.Application.Contracts.Services.Customer;
using DRR.Framework.Contracts.Markers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DRR.Application.QueryHandlers.Customer
{
    public class ReadDoctorByNameSSRQueryHandler : IQueryHandler<ReadDoctorByNameSSRQuery, ReadDoctorByNameSSRQueryResponse>
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly IDoctorService _doctorService;

        public ReadDoctorByNameSSRQueryHandler(IDoctorRepository patientRepository, IDoctorService doctorService)
        {
            _doctorRepository = patientRepository;
            _doctorService = doctorService;
        }

        public async Task<ReadDoctorByNameSSRQueryResponse> Execute(ReadDoctorByNameSSRQuery query, CancellationToken cancellationToken)
        {
            //var dtcs = await _dtcRepository.ReadDoctorTreatmentCenterByNameSSR(query.SSRName);

            //var result = new ReadDoctorTreatmentCenterByNameSSRQueryResponse
            //{
            //    Data = await _dtcService.ConvertToSSRDto(dtcs)
            //};

            //return result;

            var doctor = await _doctorRepository.ReadDoctorByNameSSR(query.SSRName);

            var result = new ReadDoctorByNameSSRQueryResponse
            {
                Data = await _doctorService.ConvertToDto(doctor)
            };

            return result;
        }

    }
}
