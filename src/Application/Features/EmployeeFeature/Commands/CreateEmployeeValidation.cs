using Application.Request.Employee;
using FluentValidation;

namespace Application.Features.EmployeeFeature.Commands
{
    /// <summary>
    ///
    /// </summary>
    public class CreateEmployeeValidation : AbstractValidator<CreateEmployeeRequest>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateEmployeeValidation"/> class.
        /// </summary>
        public CreateEmployeeValidation()
        {
            RuleFor(x => x.StaffId).NotEmpty().WithMessage("Staff Id is required");
            RuleFor(x => x.MinistryId).NotEmpty().WithMessage("Ministry is required");
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("First name is required");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Last name is required");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Invalid Email Address");
            RuleFor(x => x.PhoneNo).Length(11);
            // RuleFor(x => x.PhoneNo).Matches(@"\(?\d{3}\)?-? *\d{3}-? *-?\d{4}$");
        }
    }

    /// <summary>
    ///
    /// </summary>
    public class UpdateEmployeeValidation : AbstractValidator<UpdateEmployeeRequest>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateEmployeeValidation"/> class.
        /// </summary>
        public UpdateEmployeeValidation()
        {
            RuleFor(x => x.StaffId).NotEmpty().WithMessage("Staff Id is required");
            RuleFor(x => x.MinistryId).NotEmpty().WithMessage("Ministry is required");
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("FIrst name is required");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Last name is required");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Invalid Email Address");
            RuleFor(x => x.PhoneNo).Length(11);
            RuleFor(x => x.PhoneNo).Matches(@"\(?\d{3}\)?-? *\d{3}-? *-?\d{4}$");
        }
    }
}