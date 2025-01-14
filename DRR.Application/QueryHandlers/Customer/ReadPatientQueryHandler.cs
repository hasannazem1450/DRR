using DRR.Application.Contracts.Queries.Customer;
using DRR.Application.Contracts.Queries.Event;
using DRR.Application.Contracts.Repository.Customer;
using DRR.Application.Contracts.Repository.Event;
using DRR.Application.Contracts.Services.Customer;
using DRR.Application.Contracts.Services.Event;
using DRR.Framework.Contracts.Markers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DRR.Application.QueryHandlers.Customer
{
    public class ReadPatientQueryHandler:IQueryHandler<ReadPatientQuery, ReadPatientQueryResponse>
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IPatientService _patientService;

        public ReadPatientQueryHandler(IPatientRepository patientRepository, IPatientService patientService)
        {
            _patientRepository = patientRepository;
            _patientService = patientService;
        }

        public async Task<ReadPatientQueryResponse> Execute(ReadPatientQuery query, CancellationToken cancellationToken)
        {
            var patient = await _patientRepository.ReadPatientById(query.Id);

            var result = new ReadPatientQueryResponse
            {
                Data = await _patientService.ConvertToDto(patient)
            };

            return result;
        }

    }
}
