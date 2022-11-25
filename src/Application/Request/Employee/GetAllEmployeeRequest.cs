using Application.Response.Employee;
using MediatR;
using System.Collections.Generic;

namespace Application.Request.Employee
{
    /// <summary>
    ///
    /// </summary>
    public class GetAllEmployeeRequest : IRequest<List<GetAllEmployeeResponse>>
    {
    }
}