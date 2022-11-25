using MediatR;

namespace Application.Features.AuthenticationFeatures.Commands
{
    /// <summary>
    /// 
    /// </summary>
    public class ResetPasswordCommand : IRequest<(bool success, string message)>
    {
        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        public string Email { get; set; }
    }
}