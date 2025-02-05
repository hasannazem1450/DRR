
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
    public class ReadInsurancesQueryHandler : IQueryHandler<ReadInsurancesQuery, ReadInsurancesQueryResponse>
    {
        private readonly IInsuranceRepository _InsuranceRepository;

        public ReadInsurancesQueryHandler(IInsuranceRepository InsuranceRepository)
        {
            _InsuranceRepository = InsuranceRepository;
        }

        public async Task<ReadInsurancesQueryResponse> Execute(ReadInsurancesQuery query,
            CancellationToken cancellationToken)
        {
            var Insurances = await _InsuranceRepository.ReadAllInsurances();

            var result = new ReadInsurancesQueryResponse
            {
                List = Insurances
            };

            return result;
        }
    }
}
