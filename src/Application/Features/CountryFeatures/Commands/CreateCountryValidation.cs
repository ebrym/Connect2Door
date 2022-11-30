using Application.Request.Country;
using FluentValidation;

namespace Application.Features.UnitFeatures.Commands
{
    /// <summary>
    ///
    /// </summary>
    /// <seealso>
    ///     <cref>FluentValidation.AbstractValidator{Application.Request.Unit.CreateUnitRequest}</cref>
    /// </seealso>
    public class CreateCountryValidation : AbstractValidator<CreateCountryRequest>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateCountryValidation"/> class.
        /// </summary>
        public CreateCountryValidation()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.Code).NotEmpty().WithMessage("Code is required");
        }
    }
}