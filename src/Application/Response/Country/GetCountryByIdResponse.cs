using Application.Interfaces;

namespace Application.Response.Country
{
    /// <summary>
    ///
    /// </summary>
    /// <seealso>
    /// <cref>
    /// Application.Interfaces.IMapFrom{Domain.Entities.Country
    /// </cref>
    /// </seealso>
    public class GetCountryByIdResponse : IMapFrom<Domain.Entities.Country>
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        /// <value>
        /// The code.
        /// </value>
        public string Code { get; set; }
    }
}