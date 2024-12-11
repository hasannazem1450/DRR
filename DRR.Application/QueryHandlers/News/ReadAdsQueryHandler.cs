﻿using System;
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
    public class ReadAdsQueryHandler : IQueryHandler<ReadSmeProfileAdsQuery, ReadAdsQueryResponse>
    {
        private readonly IAdsService _adsService;


        public ReadAdsQueryHandler(IAdsService adsService)
        {
            _adsService = adsService;
        }

        public async Task<ReadAdsQueryResponse> Execute(ReadSmeProfileAdsQuery query,
            CancellationToken cancellationToken)
        {
            var adsDtos = await _adsService.ReadAdsBySmeProfileId(query.SmeProfileId);

            var result = new ReadAdsQueryResponse()
            {
                List = adsDtos,
            };

            return result;
        }
    }
}