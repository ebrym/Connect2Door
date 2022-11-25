using Application.Response.Employee;
using MediatR;

namespace Application.Request.Employee
{
    /// <summary>
    ///
    /// </summary>
    public class GetEmployeeByIdRequest : IRequest<GetEmployeeByIdResponse>
    {
        /// <summary>
        ///
        /// </summary>
        public string Id { get; set; }
    }
}