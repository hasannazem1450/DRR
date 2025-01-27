using DRR.Application.Contracts.Queries.Customer;
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
    public class ReadAllDoctorsQueryHandler : IQueryHandler<ReadAllDoctorsQuery, ReadDoctorsQueryResponse>
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly IDoctorService _doctorService;

        public ReadAllDoctorsQueryHandler(IDoctorRepository patientRepository, IDoctorService doctorService)
        {
            _doctorRepository = patientRepository;
            _doctorService = doctorService;
        }

        public async Task<ReadDoctorsQueryResponse> Execute(ReadAllDoctorsQuery query, CancellationToken cancellationToken)
        {
            var doctor = await _doctorRepository.ReadAllDoctors();

            var result = new ReadDoctorsQueryResponse
            {
                List = await _doctorService.ConvertToDto(doctor)
            };

            return result;
        }

    }
}
