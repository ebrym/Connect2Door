using Application.Interfaces;

namespace Application.Response.Company
{
    /// <summary>
    ///
    /// </summary>
    /// <seealso>
    /// <cref>
    /// Application.Interfaces.IMapFrom{Domain.Entities.Country
    /// </cref>
    /// </seealso>
    public class GetCompanyByIdResponse : IMapFrom<Domain.Entities.Company>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Website { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        public string Logo { get; set; }
        public string Banner { get; set; }

        public Domain.Entities.Country Country { get; set; }
        public string CountryId { get; set; }

        public Domain.Entities.State State { get; set; }
        public string StateId { get; set; }
    }
}