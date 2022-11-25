using Application.Response.UnitOfMeasurement;

using MediatR;

namespace Application.Request.UnitOfMeasurement
{
    /// <summary>
    ///
    /// </summary>
    /// <seealso>
    ///     <cref>MediatR.IRequest{Application.Response.Vendor.GetAllVendorResponse}</cref>
    /// </seealso>
    public class GetUnitOfMeasurementByIdRequest : IRequest<GetUnitOfMeasurementByIdResponse>
    {
        public string Id { get; set; }
    }
}