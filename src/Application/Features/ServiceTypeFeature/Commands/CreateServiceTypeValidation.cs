using Application.Request.ServiceType;
using FluentValidation;

namespace Application.Features.ServiceTypeFeature.Commands
{
    /// <summary>
    ///
    /// </summary>
    public class CreateServiceTypeValidation : AbstractValidator<CreateServiceTypeRequest>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateServiceTypeValidation"/> class.
        /// </summary>
        public CreateServiceTypeValidation()
        {
            RuleFor(x => x.ServiceTypeName).NotEmpty().WithMessage("The name is required");
        }
    }

    /// <summary>
    ///
    /// </summary>
    /// <seealso>
    ///     <cref>FluentValidation.AbstractValidator{Application.Request.ServiceType.UpdateServiceTypeRequest}</cref>
    /// </seealso>
    public class UpdateServiceTypeValidation : AbstractValidator<UpdateServiceTypeRequest>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateServiceTypeValidation"/> class.
        /// </summary>
        public UpdateServiceTypeValidation()
        {
            RuleFor(x => x.ServiceTypeName).NotEmpty().WithMessage("The name is required");
        }
    }
}