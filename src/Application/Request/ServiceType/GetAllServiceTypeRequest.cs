using Application.Response.ServiceType;
using MediatR;
using System.Collections.Generic;

namespace Application.Request.ServiceType
{
    /// <summary>
    ///
    /// </summary>
    public class GetAllServiceTypeRequest : IRequest<List<GetAllServiceTypeResponse>>
    {
    }
}