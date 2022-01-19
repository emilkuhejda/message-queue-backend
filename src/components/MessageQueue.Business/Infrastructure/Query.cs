﻿using System.Security.Claims;
using MessageQueue.Domain.Interfaces.Infrastructure;

namespace MessageQueue.Business.Infrastructure
{
    public abstract class Query<T, TResult> : IQuery<T, TResult>
    {
        protected abstract Task<TResult> Execute(T parameter, ClaimsPrincipal principal, CancellationToken cancellationToken);

        public async Task<TResult> ExecuteAsync(T parameter, ClaimsPrincipal principal, CancellationToken cancellationToken)
        {
            return await Execute(parameter, principal, cancellationToken);
        }
    }

    public abstract class Query<TResult> : IQuery<TResult>
    {
        protected abstract Task<TResult> Execute(ClaimsPrincipal principal, CancellationToken cancellationToken);

        public async Task<TResult> ExecuteAsync(ClaimsPrincipal principal, CancellationToken cancellationToken)
        {
            return await Execute(principal, cancellationToken);
        }
    }
}
