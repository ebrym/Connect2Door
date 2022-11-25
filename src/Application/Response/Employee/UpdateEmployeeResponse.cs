using Application.Interfaces;
using Application.Request.Employee;

namespace Application.Response.Employee
{
    /// <summary>
    ///
    /// </summary>
    public class UpdateEmployeeResponse : IMapFrom<UpdateEmployeeRequest>
    {
        /// <summary>
        ///
        /// </summary>
        public string Id { get; set; }
    }
}