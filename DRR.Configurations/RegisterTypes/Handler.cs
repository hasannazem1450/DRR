using System;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using DRR.Framework.Contracts.Abstracts;
using DRR.Framework.Contracts.Makers;
using DRR.Framework.Contracts.Markers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DRR.Configurations.RegisterTypes;

public class Distributor : IDistributor
{
    private readonly IServiceCollection _serviceCollection;
    private bool _resolved;
    private ServiceProvider _serviceProvider;
    private IHttpContextAccessor _httpContextAccessor;


    public Distributor(IServiceCollection serviceCollection)
    {
        _serviceCollection = serviceCollection;
    }

    public Task<R> Push<C, R>(C command, CancellationToken cancellationToken)
        where C : Command
        where R : CommandResponse
    {
        ServiceResolved();

        var handler = _serviceProvider.GetRequiredService(typeof(ICommandHandler<C, R>)) as ICommandHandler<C, R>;

        command.Metadata = GetMetadata();

        var commandResponse = handler.Execute(command, cancellationToken);

        return commandResponse;
    }

    public Task<R> Send<Q, R>(Q query, CancellationToken cancellationToken)
        where Q : Query
        where R : QueryResponse
    {
        ServiceResolved();

        var handler = _serviceProvider.GetService(typeof(IQueryHandler<Q, R>)) as IQueryHandler<Q, R>;

        query.Metadata = GetMetadata();

        var queryResponse = handler.Execute(query, cancellationToken);

        return queryResponse;
    }

    private Metadata GetMetadata()
    {
        var result = new Metadata();

        if (_httpContextAccessor.HttpContext != null && _httpContextAccessor.HttpContext.User.Claims.Any())
        {
            var claims = _httpContextAccessor.HttpContext.User.Claims;

            var name = claims.FirstOrDefault(x => x.Type == ClaimTypes.Name);

            var identifier = claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);

            result.UserName = name.Value;

            result.UserId = Guid.Parse(_httpContextAccessor.HttpContext.User.Identity.Name);
        }

        return result;
    }

    private void ServiceResolved()
    {
        if (!_resolved)
        {
            _resolved = true;

            _serviceProvider = _serviceCollection.BuildServiceProvider();

            _httpContextAccessor = _serviceProvider.GetRequiredService<IHttpContextAccessor>();
        }
    }
}