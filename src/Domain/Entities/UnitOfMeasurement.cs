using Domain.Common;

namespace Domain.Entities
{
    /// <summary>
    ///
    /// </summary>
    /// <seealso cref="Domain.Common.BaseEntity" />
    public class UnitOfMeasurement : BaseEntity
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
    }
}