using Application.Request.FileUpload;
using FluentValidation;

namespace Application.Features.FileUploadFeature.Command
{
    /// <summary>
    ///
    /// </summary>
    /// <seealso cref="AbstractValidator{FileUploadRequest}" />
    public class FileUploadValidation : AbstractValidator<FileUploadRequest>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FileUploadValidation"/> class.
        /// </summary>
        public FileUploadValidation()
        {
            RuleFor(x => x.EntityId).NotEmpty().WithMessage("Entity id is required");
            RuleFor(x => x.EntityType).NotEmpty();
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}