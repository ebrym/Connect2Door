using Application.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.ServiceTypeFeature.Commands
{
    /// <summary>
    ///
    /// </summary>
    /// <seealso cref="MediatR.IRequest{(System.Boolean succeed, System.String message)}" />
    public class DeleteServiceTypeCommand : IRequest<(bool succeed, string message)>
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public string Id { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <seealso cref="MediatR.IRequestHandler{Application.Features.ServiceTypeFeature.Commands.DeleteServiceTypeCommand, (System.Boolean succeed, System.String message)}" />
        private class DeleteServiceTypeCommandHandler : IRequestHandler<DeleteServiceTypeCommand, (bool succeed, string message)>
        {
            private readonly IApplicationDbContext applicationDbContext;

            /// <summary>
            /// Initializes a new instance of the <see cref="DeleteServiceTypeCommandHandler"/> class.
            /// </summary>
            /// <param name="applicationDbContext">The application database context.</param>
            public DeleteServiceTypeCommandHandler(IApplicationDbContext applicationDbContext)
            {
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
            public async Task<(bool succeed, string message)> Handle(DeleteServiceTypeCommand request, CancellationToken cancellationToken)
            {
                var serviceType = await applicationDbContext.ServiceTypes.FindAsync(request.Id);
                if (serviceType != null)
                {
                    serviceType.IsDeleted = true;
                    await applicationDbContext.SaveChangesAsync(cancellationToken);
                    return (true, "Service Tye has been deleted successfully");
                }
                else
                {
                    return (false, "The service type is not found");
                }
            }
        }
    }
}