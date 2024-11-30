using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace Identity.Application.Behaviours
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validator)
        {
            this.validators = validator;
        }

        public Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            ValidationContext<object> context = new(request);
            List<ValidationFailure> failures = validators.
                Select(validator => validator.Validate(context))
                .SelectMany(c => c.Errors).Where(failure => failure != null)
                .ToList();

            if (failures.Count > 0) throw new ValidationException(failures);

            return next();
        }

    }
}
