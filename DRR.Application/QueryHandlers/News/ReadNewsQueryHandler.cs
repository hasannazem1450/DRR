using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DRR.Application.Contracts.Queries.News;
using DRR.Application.Contracts.Repository.News;
using DRR.Application.Contracts.Services.News;
using DRR.Application.Contracts.Services.Profile.Member;
using DRR.Framework.Contracts.Markers;

namespace DRR.Application.QueryHandlers.News
{
    public class ReadNewsQueryHandler : IQueryHandler<ReadSmeProfileNewsQuery, ReadNewsQueryResponse>
    {
        private readonly INewsService _newsService;


        public ReadNewsQueryHandler(INewsService newsService)
        {
            _newsService = newsService;
        }

        public async Task<ReadNewsQueryResponse> Execute(ReadSmeProfileNewsQuery query,
            CancellationToken cancellationToken)
        {
            var newsDtos = await _newsService.ReadNewsBySmeProfileId(query.SmeProfileId);

            var result = new ReadNewsQueryResponse()
            {
                List = newsDtos,
            };

            return result;
        }
    }
}
