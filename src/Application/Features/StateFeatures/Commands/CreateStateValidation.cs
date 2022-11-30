using Application.Request.State;
using FluentValidation;

namespace Application.Features.UnitFeatures.Commands
{
    /// <summary>
    ///
    /// </summary>
    /// <seealso>
    ///     <cref>FluentValidation.AbstractValidator{Application.Request.Unit.CreateUnitRequest}</cref>
    /// </seealso>
    public class CreateStateValidation : AbstractValidator<CreateStateRequest>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateStateValidation"/> class.
        /// </summary>
        public CreateStateValidation()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.Code).NotEmpty().WithMessage("Code is required");
        }
    }
}