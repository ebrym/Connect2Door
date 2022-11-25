using Application.Interfaces;
using Application.Request.User;
using Application.Response.User;
using Domain.User;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.AuthenticationFeatures.Commands
{
    /// <summary>
    ///
    /// </summary>
    /// <seealso>
    /// <cref>MediatR.IRequestHandler{Application.Request.User.AuthenticateRequest, (System.Boolean Succeed, System.String Message, System.Object user)}</cref>
    /// </seealso>
    public class AuthenticateCommandHandler : IRequestHandler<AuthenticateRequest, (bool Succeed, string Message, (object user, object userLocation))>
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly IApplicationDbContext applicationDbContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticateCommandHandler"/> class.
        /// </summary>
        /// <param name="userManager">The user manager.</param>
        /// <param name="signInManager">The sign in manager.</param>
        /// <param name="applicationDbContext"></param>
        public AuthenticateCommandHandler(UserManager<User> userManager, SignInManager<User> signInManager, IApplicationDbContext applicationDbContext)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.applicationDbContext = applicationDbContext;
        }

        /// <summary>
        /// Handles a request
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>
        /// Response from the request
        /// </returns>
        public async Task<(bool Succeed, string Message, (object user, object userLocation))> Handle(AuthenticateRequest request, CancellationToken cancellationToken)
        {
            var user = await userManager.FindByEmailAsync(request.Email);
            if (user == null) user = await userManager.FindByNameAsync(request.Username);
            if (user != null)
            {
                if (user.IsDeleted)
                {
                    return (false, "The user has been deleted", (null, null));
                }

                var result = await signInManager.CheckPasswordSignInAsync(user, request.Password, lockoutOnFailure: true);
                if (result.Succeeded)
                {
                    return (true, "User has been authenticated successfully", (user, null));
                    
                }
                else if (result.IsLockedOut)
                {
                    return (false, "The user has been locked out", (null, null));
                }
                else if (result.RequiresTwoFactor)
                {
                    return (false, "The requires two factor authentication", (user, null));
                }
                else if (result.IsNotAllowed)
                {
                    return (false, "The user is not allowed", (null, null));
                }
            }
            else
            {
                return (false, "Invalid login  attempt ", (null, null));
            }

            return (false, "Unable to login user, invalid request", (null, null));
        }
    }
}