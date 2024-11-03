using DRR.Framework.Contracts.Abstracts;
using System.Threading;
using System.Threading.Tasks;

namespace DRR.Framework.Contracts.Makers;

public interface ICommandHandler<C, R> where C : Command where R : CommandResponse
{
    Task<R> Execute(C command, CancellationToken cancellationToken);
}