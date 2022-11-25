using Application.Interfaces;
using Application.Response.State;
using MediatR;

namespace Application.Request.State
{
    public class UpdateStateRequest : IRequest<(bool Succeed, string Message, UpdateStateResponse Response)>, IMapFrom<Domain.Entities.State>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }

        public string CountryId { get; set; }
    }
}