using Application.Interfaces;
using Application.Request.UnitOfMeasurement;

namespace Application.Response.UnitOfMeasurement
{
    /// <summary>
    ///
    /// </summary>
    public class DeleteUnitOfMeasurementResponse : IMapFrom<CreateUnitOfMeasurementRequest>
    {
        /// <summary>
        ///
        /// </summary>
        public string Id { get; set; }
    }
}