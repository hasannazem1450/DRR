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
    public class ReadPatientsQueryHandler : IQueryHandler<ReadPatientBySmeProfileIdQuery, ReadPatientsQueryResponse>
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IPatientService _patientService;

        public ReadPatientsQueryHandler(IPatientRepository patientRepository, IPatientService patientService)
        {
            _patientRepository = patientRepository;
            _patientService = patientService;
        }

        public async Task<ReadPatientsQueryResponse> Execute(ReadPatientBySmeProfileIdQuery query, CancellationToken cancellationToken)
        {
            var patients = await _patientRepository.ReadPatientBySmeProfileId(query.SmeProfileIdId);

            var result = new ReadPatientsQueryResponse
            {
                List = await _patientService.ConvertToDto(patients)
            };

            return result;
        }
    }
}
