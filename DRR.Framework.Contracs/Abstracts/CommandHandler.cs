using System.Threading;
using System.Threading.Tasks;
using System.Transactions;
using DRR.Framework.Contracts.Makers;

namespace DRR.Framework.Contracts.Abstracts;

public abstract class CommandHandler<C, R> : ICommandHandler<C, R> where C : Command where R : CommandResponse
{
    private readonly bool _isTransactional;

    public CommandHandler()
    {

    }

    public CommandHandler(bool isTransactional)
    {
        _isTransactional = isTransactional;
    }

    public Task<R> Execute(C command, CancellationToken cancellationToken)
    {
        if (cancellationToken.IsCancellationRequested)
        {
            return Task.FromResult((R)CommandResponseCanceled.CreateCanceled());
        }

        if (_isTransactional)
        {
            dynamic result;

            using (var scope = new TransactionScope())
            {
                result = Executor(command);

                scope.Complete();
            }

            return result;
        }
        else
        {
            return Executor(command);
        }
    }

    public abstract Task<R> Executor(C command);
}