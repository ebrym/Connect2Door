using Application.Response.Company;
using MediatR;
using System.Collections.Generic;

namespace Application.Request.Company
{
    /// <summary>
    ///
    /// </summary>
    /// <seealso>
    ///     <cref>MediatR.IRequest{Application.Response.Vendor.GetAllVendorResponse}</cref>
    /// </seealso>
    public class GetAllCompanyRequest : IRequest<List<GetAllCompanyResponse>>
    {
    }
}