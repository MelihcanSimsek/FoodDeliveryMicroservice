using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentService.Application.Behaviours
{
    public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> validator;

        public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
        {
            validator = validators;
        }

        public Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var context = new ValidationContext<TRequest>(request);
            var failures = validator.Select(p => p.Validate(context))
                .SelectMany(c => c.Errors).Where(failure => failure != null)
                .ToList();

            if (failures.Any()) throw new ValidationException(failures);

            return next();
        }
    }
}
