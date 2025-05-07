using DRR.Application.Contracts.Queries.Customer;
using DRR.Application.Contracts.Repository.Customer;
using DRR.Application.Contracts.Services.Customer;
using DRR.Application.Services.Customer;
using DRR.Domain.Customer;
using DRR.Framework.Contracts.Markers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DRR.Application.QueryHandlers.Customer
{
    public class ReadPatientFavoritesQueryHandler : IQueryHandler<ReadPatientFavoritesQuery, ReadPatientFavoritesQueryResponse>
    {
        private readonly IPatientFavoriteRepository _pfRepository;
        private readonly IPatientFavoriteService _pfService;

        public ReadPatientFavoritesQueryHandler(IPatientFavoriteRepository pfRepository, IPatientFavoriteService pfService)
        {
            _pfRepository = pfRepository;
            _pfService = pfService;
        }

        public async Task<ReadPatientFavoritesQueryResponse> Execute(ReadPatientFavoritesQuery query, CancellationToken cancellationToken)
        {
            var pf = await _pfRepository.ReadPatientFavoriteByPatientId(query.PatientId);

            var result = new ReadPatientFavoritesQueryResponse
            {
                List = await _pfService.ConvertToDto(pf)
            };

            return result;
        }
    }
}
