using Application.Request.ItemType;
using FluentValidation;

namespace Application.Features.ItemTypeFeatures.Commands
{
    /// <summary>
    ///
    /// </summary>
    public class CreateItemTypeValidation : AbstractValidator<CreateItemTypeRequest>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateItemTypeValidation"/> class.
        /// </summary>
        public CreateItemTypeValidation()
        {
            RuleFor(x => x.ItemTypeName).NotEmpty().WithMessage("The name is required");
        }
    }

    /// <summary>
    ///
    /// </summary>
    /// <seealso>
    ///     <cref>FluentValidation.AbstractValidator{Application.Request.ItemType.UpdateItemTypeRequest}</cref>
    /// </seealso>
    public class UpdateItemTypeValidation : AbstractValidator<UpdateItemTypeRequest>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateItemTypeValidation"/> class.
        /// </summary>
        public UpdateItemTypeValidation()
        {
            RuleFor(x => x.ItemTypeName).NotEmpty().WithMessage("The name is required");
        }
    }
}