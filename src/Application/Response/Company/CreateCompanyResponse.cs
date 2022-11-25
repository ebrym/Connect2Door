using Application.Interfaces;
using Application.Request.Company;

namespace Application.Response.Company
{
    /// <summary>
    ///
    /// </summary>
    public class CreateCompanyResponse : IMapFrom<CreateCompanyRequest>
    {
        /// <summary>
        ///
        /// </summary>
        public string Id { get; set; }
    }
}