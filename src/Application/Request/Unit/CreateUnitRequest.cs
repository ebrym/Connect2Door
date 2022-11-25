using Application.Interfaces;
using Application.Response.Unit;
using MediatR;

namespace Application.Request.Unit
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

    public class CreateUnitRequest : IRequest<(bool Succeed, string Message, CreateUnitResponse Response)>, IMapFrom<Domain.Entities.Unit>
    {
        /// <summary>
        ///
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        /// <value>
        /// The code.
        /// </value>
        public string Code { get; set; }
        /// <summary>
        /// Gets or sets the department identifier.
        /// </summary>
        /// <value>
        /// The department identifier.
        /// </value>
        public string DepartmentId { get; set; }

        /// <summary>
        /// Gets or sets the ministry identifier.
        /// </summary>
        /// <value>
        /// The ministry identifier.
        /// </value>
        public string MinistryId { get; set; }
    }
}