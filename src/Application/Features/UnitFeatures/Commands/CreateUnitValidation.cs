using Application.Request.Unit;
using FluentValidation;

namespace Application.Features.UnitFeatures.Commands
{
    /// <summary>
    ///
    /// </summary>
    /// <seealso>
    ///     <cref>FluentValidation.AbstractValidator{Application.Request.Unit.CreateUnitRequest}</cref>
    /// </seealso>
    public class CreateUnitValidation : AbstractValidator<CreateUnitRequest>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateUnitValidation"/> class.
        /// </summary>
        public CreateUnitValidation()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.Code).NotEmpty().WithMessage("Code is required");
        }
    }
}