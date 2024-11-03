using DRR.Framework.Contracts.Abstracts;
using System.Threading;
using System.Threading.Tasks;

namespace DRR.Framework.Contracts.Makers;

public interface IDistributor
{
    Task<R> Push<C, R>(C command, CancellationToken cancellationToken) where C : Command where R : CommandResponse;

    Task<R> Send<Q, R>(Q query, CancellationToken cancellationToken) where Q : Query where R : QueryResponse;

}