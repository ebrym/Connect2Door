using Application.Interfaces;
using Application.Request.UnitOfMeasurement;

namespace Application.Response.UnitOfMeasurement
{
    /// <summary>
    ///
    /// </summary>
    public class CreateUnitOfMeasurementResponse : IMapFrom<CreateUnitOfMeasurementRequest>
    {
        /// <summary>
        ///
        /// </summary>
        public string Id { get; set; }
    }
}