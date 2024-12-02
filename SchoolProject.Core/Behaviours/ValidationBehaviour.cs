using FluentValidation;
using MediatR;

namespace SchoolProject.Core.Behaviours
{
    public class ValidationBehaviour<TRequest, TResponse> :
        IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (_validators.Any())
            {
                var validationContext = new ValidationContext<TRequest>(request);
                var validationsResults = await Task.WhenAll(
                    _validators.Select(vld => vld.ValidateAsync(validationContext,
                    cancellationToken)));

                var failures = validationsResults.SelectMany(vld => vld.Errors)
                    .Where(vld => vld is not null).ToList();

                if (failures.Any())
                {
                    var message = failures.Select(vld => vld.ErrorMessage).FirstOrDefault();

                    throw new ValidationException(message);
                }
            }
            return await next();
        }
    }
}
