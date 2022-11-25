using Application.Response.UnitOfMeasurement;
using MediatR;
using System.Collections.Generic;

namespace Application.Request.UnitOfMeasurement
{
    /// <summary>
    ///
    /// </summary>
    /// <seealso>
    ///     <cref>MediatR.IRequest{Application.Response.Vendor.GetAllVendorResponse}</cref>
    /// </seealso>
    public class GetAllUnitOfMeasurementRequest : IRequest<List<GetAllUnitOfMeasurementResponse>>
    {
    }
}