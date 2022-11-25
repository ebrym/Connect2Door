using Application.Interfaces;
using Application.Response.LocalGovernment;
using MediatR;

namespace Application.Request.LocalGovernment
{
    public class UpdateLocalGovernmentRequest : IRequest<(bool Succeed, string Message, UpdateLocalGovernmentResponse Response)>, IMapFrom<Domain.Entities.LocalGovernment>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the StateId.
        /// </summary>
        /// <value>
        /// The StateId.
        /// </value>
        public string StateId { get; set; }
    }
}