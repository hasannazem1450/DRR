using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRR.Application.Contracts.Commands.Event;
using DRR.Application.Contracts.Commands.News;
using DRR.Application.Contracts.Commands.Profile.Position;
using DRR.Framework.Contracts.Abstracts;

namespace DRR.Application.Contracts.Queries.News
{
    public class ReadAdsQuery : Query
    {
    }
    public class ReadSmeProfileAdsQuery : Query
    {
        public int SmeProfileId { get; set; }
    }

    public class ReadAdsQueryResponse : QueryResponse
    {
        public ReadAdsQueryResponse()
        {
            List = new List<AdsDto>();
        }
        public List<AdsDto> List { get; set; }
    }

}
