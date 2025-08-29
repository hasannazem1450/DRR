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
    public class ReadVisitTypeQueryHandler : IQueryHandler<ReadVisitTypeQuery, ReadVisitTypeQueryResponse>
    {
        private IVisitTypeRepository _visitTypeRepository;
        public ReadVisitTypeQueryHandler(IVisitTypeRepository visitTypeRepository)
        {
            _visitTypeRepository = visitTypeRepository;
        }

        public async Task<ReadVisitTypeQueryResponse> Execute(ReadVisitTypeQuery query, CancellationToken cancellationToken)
        {
            var visitTypes = await _visitTypeRepository.ReadVisitTypes();

            var result = new ReadVisitTypeQueryResponse
            {
                List = visitTypes
            };

            return result;
        }
    }
}
