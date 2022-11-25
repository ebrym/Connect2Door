using Application.Interfaces;
using Application.Response.Employee;
using MediatR;

namespace Application.Request.Employee
{
    /// <summary>
    /// 1.Name (unique)
    ///2.Website
    ///3.Description
    ///4.Email
    ///5.PhoneNo
    ///6.ContactPerson
    ///7. Status(True or false)
    /// </summary>
    ///     public class CreateVendorRequest :  IRequest<(bool Succeed, string Message, CreateMinistryResponse Response)>, IMapFrom<Domain.Entities.Vendor>

    public class DeleteEmployeeRequest : IRequest<(bool Succeed, string Message, DeleteEmployeeResponse Response)>, IMapFrom<Domain.Entities.Employee>
    {
        /// <summary>
        ///
        /// </summary>
        public string Id { get; set; }
    }
}