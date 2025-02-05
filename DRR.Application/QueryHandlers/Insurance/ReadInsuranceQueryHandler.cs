
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
    public class ReadInsuranceQueryHandler : IQueryHandler<ReadInsuranceQuery, ReadInsuranceQueryResponse>
    {
        private readonly IInsuranceRepository _InsuranceRepository;

        public ReadInsuranceQueryHandler(IInsuranceRepository InsuranceRepository)
        {
            _InsuranceRepository = InsuranceRepository;
        }

        public async Task<ReadInsuranceQueryResponse> Execute(ReadInsuranceQuery query,
            CancellationToken cancellationToken)
        {
            var Insurance = await _InsuranceRepository.ReadInsuranceById(query.Id);

            var result = new ReadInsuranceQueryResponse
            {
                Data = Insurance
            };

            return result;
        }
    }
}
