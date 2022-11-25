using Application.Interfaces;
using Application.Request.UnitOfMeasurement;

namespace Application.Response.UnitOfMeasurement
{
    /// <summary>
    ///
    /// </summary>
    /// <seealso >
    /// <Cref>
    /// Application.Interfaces.IMapFrom{Application.Request.Unit.UpdateUnitRequest}
    /// </Cref>
    /// </seealso>
    public class UpdateUnitOfMeasurementResponse : IMapFrom<UpdateUnitOfMeasurementRequest>
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public string Id { get; set; }
    }
}