using DRR.Application.Contracts.Queries.Profile.SmeTypeReturn;
using DRR.Framework.Contracts.Common.Enums;
using DRR.Framework.Contracts.Markers;
using DRR.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DRR.Application.QueryHandlers.Profile.SmeTypeReturn
{
    public class ReadAllSmeTypeQueryHandler : IQueryHandler<ReadAllSmeTypesQuery, ReadAllSmeTypesQueryResponse>
    {
        public ReadAllSmeTypeQueryHandler()
        {

        }

        public async Task<ReadAllSmeTypesQueryResponse> Execute(ReadAllSmeTypesQuery query, CancellationToken cancellationToken)
        {
            var smeTypes = Enum.GetValues<SmeType>();

            var result = new ReadAllSmeTypesQueryResponse
            {
                List = smeTypes.Select(s => new SmeTypeDto { Name = s.GetDescription(), Value = (int)s }).ToList()
            };

            return result;
        }
    }
}
