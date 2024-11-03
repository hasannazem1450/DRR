using DRR.Application.Contracts.Queries.Event;
using DRR.Framework.Contracts.Common.Enums;
using DRR.Framework.Contracts.Markers;
using DRR.Utilities.Extensions;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DRR.Application.QueryHandlers.Event;

public class ReadAttenderTypesQueryHandler : IQueryHandler<ReadAttenderTypesQuery, ReadAttenderTypesQueryResponse>
{
    public async Task<ReadAttenderTypesQueryResponse> Execute(ReadAttenderTypesQuery query,
        CancellationToken cancellationToken)
    {
        var smeTypes = Enum.GetValues<EventAttenderType>();
        
        var result = new ReadAttenderTypesQueryResponse
        {
            List = smeTypes.Select(s => new EventAttenderTypeDto
            {
                Value = (int)s,
                Name = s.GetDescription()
            }).ToList()
        };

        return result;
    }
}