using Application.Request.LocalGovernment;
using FluentValidation;

namespace Application.Features.UnitFeatures.Commands
{
    /// <summary>
    ///
    /// </summary>
    /// <seealso>
    ///     <cref>FluentValidation.AbstractValidator{Application.Request.Unit.CreateUnitRequest}</cref>
    /// </seealso>
    public class CreateLocalGovernmentValidation : AbstractValidator<CreateLocalGovernmentRequest>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateLocalGovernmentValidation"/> class.
        /// </summary>
        public CreateLocalGovernmentValidation()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.Code).NotEmpty().WithMessage("Code is required");
        }
    }
}