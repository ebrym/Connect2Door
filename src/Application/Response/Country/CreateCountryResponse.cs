using Application.Interfaces;
using Application.Request.Country;

namespace Application.Response.Country
{
    /// <summary>
    ///
    /// </summary>
    public class CreateCountryResponse : IMapFrom<CreateCountryRequest>
    {
        /// <summary>
        ///
        /// </summary>
        public string Id { get; set; }
    }
}