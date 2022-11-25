using Application.Interfaces;
using Application.Response.Unit;
using MediatR;

namespace Application.Request.Unit
{
    public class UpdateUnitRequest : IRequest<(bool Succeed, string Message, UpdateUnitResponse Response)>, IMapFrom<Domain.Entities.Unit>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }

        public string DepartmentId { get; set; }

        /// <summary>
        /// Gets or sets the ministry identifier.
        /// </summary>
        /// <value>
        /// The ministry identifier.
        /// </value>
        public string MinistryId { get; set; }
    }
}