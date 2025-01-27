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
    public class ReadDoctorsBySpecialityQueryHandler : IQueryHandler<ReadDoctorsBySpecialityQuery, ReadDoctorsQueryResponse>
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly IDoctorService _doctorService;

        public ReadDoctorsBySpecialityQueryHandler(IDoctorRepository doctorRepository, IDoctorService doctorService)
        {
            _doctorRepository = doctorRepository;
            _doctorService = doctorService;
        }

        public async Task<ReadDoctorsQueryResponse> Execute(ReadDoctorsBySpecialityQuery query, CancellationToken cancellationToken)
        {
            var doctors = await _doctorRepository.ReadDoctorBySpecialistId(query.SpecialistId);

            var result = new ReadDoctorsQueryResponse
            {
                List = await _doctorService.ConvertToDto(doctors)
            };

            return result;
        }

    }
}