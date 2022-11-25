using Application.Request.Company;
using FluentValidation;

namespace Application.Features.UnitFeatures.Commands
{
    /// <summary>
    ///
    /// </summary>
    /// <seealso>
    ///     <cref>FluentValidation.AbstractValidator{Application.Request.Unit.CreateUnitRequest}</cref>
    /// </seealso>
    public class CreateCompanyValidation : AbstractValidator<CreateCompanyRequest>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateCompanyValidation"/> class.
        /// </summary>
        public CreateCompanyValidation()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.CountryId).NotEmpty().WithMessage("Country is required");
            RuleFor(x => x.StateId).NotEmpty().WithMessage("State is required");
        }
    }
}