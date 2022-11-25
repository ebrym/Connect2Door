using Application.Interfaces;
using Application.Response.Company;
using MediatR;

namespace Application.Request.Company
{
    public class UpdateCompanyRequest : IRequest<(bool Succeed, string Message, UpdateCompanyResponse Response)>, IMapFrom<Domain.Entities.Company>
    {
        public string Name { get; set; }
        public string Website { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        public string Logo { get; set; }
        public string Banner { get; set; }

        public string CountryId { get; set; }

        public string StateId { get; set; }
    }
}