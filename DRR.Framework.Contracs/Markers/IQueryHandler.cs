using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DRR.Framework.Contracts.Abstracts;

namespace DRR.Framework.Contracts.Markers
{
    public interface IQueryHandler<Q, R> where Q : Query where R : QueryResponse
    {
        Task<R> Execute(Q query, CancellationToken cancellationToken);
    }
}
