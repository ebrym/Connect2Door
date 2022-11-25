using Application.Interfaces;

namespace Application.Response.LocalGovernment
{
    /// <summary>
    ///
    /// </summary>
    /// <seealso >
    /// <cref>
    /// Application.Interfaces.IMapFrom{Domain.Entities.LocalGovernment}
    /// </cref>
    /// </seealso>
    public class GetAllLocalGovernmentResponse : IMapFrom<Domain.Entities.LocalGovernment>
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

        /// <summary>
        /// Gets or sets the Country.
        /// </summary>
        /// <value>
        /// The Country.
        /// </value>
        public Domain.Entities.State State { get; set; }

        /// <summary>
        /// Gets or sets the CountryId.
        /// </summary>
        /// <value>
        /// The CountryId.
        /// </value>
        public string StateId { get; set; }
    }
}