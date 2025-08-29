using DRR.Application.Contracts.Queries.Reserv;
using DRR.Application.Contracts.Repository.Reserv;
using DRR.Application.Contracts.Services.Reserv;
using DRR.Application.Services.Reserv;
using DRR.CommandDb.Repository.Reserv;
using DRR.Framework.Contracts.Markers;
using System.Threading;
using System.Threading.Tasks;

namespace DRR.Application.QueryHandlers.Reservation
{
    public class ReadVisitCostQueryHandler : IQueryHandler<ReadVisitCostQuery, ReadVisitCostQueryResponse>
    {
        private IVisitCostRepository _visitCostRepository;
        public ReadVisitCostQueryHandler(IVisitCostRepository visitCostRepository)
        {
            _visitCostRepository = visitCostRepository;
        }

        public async Task<ReadVisitCostQueryResponse> Execute(ReadVisitCostQuery query, CancellationToken cancellationToken)
        {
            var visitcosts = await _visitCostRepository.ReadVisitCosts();

            var result = new ReadVisitCostQueryResponse
            {
                List = visitcosts
            };

            return result;
        }
    }
}
