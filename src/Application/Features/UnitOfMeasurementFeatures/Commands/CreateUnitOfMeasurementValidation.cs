using Application.Request.UnitOfMeasurement;
using FluentValidation;

namespace Application.Features.UnitFeatures.Commands
{
    /// <summary>
    ///
    /// </summary>
    /// <seealso>
    ///     <cref>FluentValidation.AbstractValidator{Application.Request.Unit.CreateUnitRequest}</cref>
    /// </seealso>
    public class CreateUnitOfMeasurementValidation : AbstractValidator<CreateUnitOfMeasurementRequest>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateUnitOfMeasurementValidation"/> class.
        /// </summary>
        public CreateUnitOfMeasurementValidation()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.Code).NotEmpty().WithMessage("Code is required");
        }
    }
}