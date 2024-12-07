﻿using MediatR;
using Microsoft.AspNetCore.Http;
using OrderService.Application.Exceptions;
using OrderService.Application.Extensions;
using OrderService.Application.Interfaces.Authorization;


namespace OrderService.Application.Behaviours
{
    public class AuthorizationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>, ISecuredRequest
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public AuthorizationBehaviour(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        public Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            IList<string> roles = httpContextAccessor.HttpContext.User.ClaimRoles();

            if (roles is null) throw new AuthorizationException("Role not found");

            bool userHaveRole = roles.FirstOrDefault(roleClaim => request.Roles.Any(role => role == roleClaim)) is not null;

            if (!userHaveRole) throw new AuthorizationException("You are not authorized.");

            return next();
        }
    }
}