using DRR.Application.Contracts.Queries.Insurance;
using DRR.Application.Contracts.Repository.Insurance;
using DRR.Framework.Contracts.Markers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DRR.Application.QueryHandlers.Insurance
{
    public class ReadDoctorInsurancesQueryHandler : IQueryHandler<ReadDoctorInsurancesQuery, ReadDoctorInsurancesQueryResponse>
    {
        private readonly IDoctorInsuranceRepository _diRepository;
        private readonly IInsuranceRepository _insuranceRepository;

        public ReadDoctorInsurancesQueryHandler(IDoctorInsuranceRepository diRepository, IInsuranceRepository insuranceRepository)
        {
            _diRepository = diRepository;
            _insuranceRepository = insuranceRepository; 
        }

        public async Task<ReadDoctorInsurancesQueryResponse> Execute(ReadDoctorInsurancesQuery query, CancellationToken cancellationToken)
        {
            var insurances = await _diRepository.ReadInsurancesByDoctorId(query.DoctorId);

            var result = new ReadDoctorInsurancesQueryResponse
            {
                List = insurances
            };

            return result;
        }

    }
}
