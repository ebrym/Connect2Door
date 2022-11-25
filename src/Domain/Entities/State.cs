using Domain.Common;

namespace Domain.Entities
{
    /// <summary>
    ///
    /// </summary>
    /// <seealso cref="Domain.Common.BaseEntity" />
    public class State : BaseEntity
    {
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
        public Country Country { get; set; }

        /// <summary>
        /// Gets or sets the CountryId.
        /// </summary>
        /// <value>
        /// The CountryId.
        /// </value>
        public string CountryId { get; set; }
    }
}