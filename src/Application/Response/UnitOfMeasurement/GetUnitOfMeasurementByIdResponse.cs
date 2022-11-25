using Application.Interfaces;

namespace Application.Response.UnitOfMeasurement
{
    /// <summary>
    ///
    /// </summary>
    /// <seealso>
    /// <cref>
    /// Application.Interfaces.IMapFrom{Domain.Entities.UnitOfMeasurement
    /// </cref>
    /// </seealso>
    public class GetUnitOfMeasurementByIdResponse : IMapFrom<Domain.Entities.UnitOfMeasurement>
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