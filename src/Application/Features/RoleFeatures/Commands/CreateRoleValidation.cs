using Application.Request.Role;
using FluentValidation;

namespace Application.Features.RoleFeatures.Commands
{
    /// <summary>
    ///
    /// </summary>
    /// <seealso>
    ///     <cref>FluentValidation.AbstractValidator{Application.Request.Role.CreateRoleRequest}</cref>
    /// </seealso>
    public class CreateRoleValidation : AbstractValidator<CreateRoleRequest>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateRoleValidation"/> class.
        /// </summary>
        public CreateRoleValidation()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
        }
    }
}