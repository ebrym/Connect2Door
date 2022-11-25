using Application.Interfaces;
using Application.Response.Country;
using MediatR;

namespace Application.Request.Country
{
    public class UpdateCountryRequest : IRequest<(bool Succeed, string Message, UpdateCountryResponse Response)>, IMapFrom<Domain.Entities.Country>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
    }
}