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
    public class ReadDoctorQueryHandler : IQueryHandler<ReadDoctorQuery, ReadDoctorQueryResponse>
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly IDoctorService _doctorService;

        public ReadDoctorQueryHandler(IDoctorRepository patientRepository, IDoctorService doctorService)
        {
            _doctorRepository = patientRepository;
            _doctorService = doctorService;
        }

        public async Task<ReadDoctorQueryResponse> Execute(ReadDoctorQuery query, CancellationToken cancellationToken)
        {
            var doctor = await _doctorRepository.ReadDoctorById(query.Id);

            var result = new ReadDoctorQueryResponse
            {
                Data = await _doctorService.ConvertToDto(doctor)
            };

            return result;
        }

    }
}
