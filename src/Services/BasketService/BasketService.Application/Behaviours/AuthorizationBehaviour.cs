using BasketService.Application.Exceptions;
using BasketService.Application.Extensions;
using BasketService.Application.Interfaces.Authorization;
using MediatR;
using Microsoft.AspNetCore.Http;


namespace BasketService.Application.Behaviours
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
