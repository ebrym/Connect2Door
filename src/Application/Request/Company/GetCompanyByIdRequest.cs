using Application.Response.Company;

using MediatR;

namespace Application.Request.Company
{
    /// <summary>
    ///
    /// </summary>
    /// <seealso>
    ///     <cref>MediatR.IRequest{Application.Response.Vendor.GetAllVendorResponse}</cref>
    /// </seealso>
    public class GetCompanyByIdRequest : IRequest<GetCompanyByIdResponse>
    {
        public string Id { get; set; }
    }
}