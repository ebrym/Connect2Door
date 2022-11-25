using Application.Interfaces;
using Application.Response.LocalGovernment;
using MediatR;

namespace Application.Request.LocalGovernment
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

    public class DeleteLocalGovernmentRequest : IRequest<(bool Succeed, string Message, DeleteLocalGovernmentResponse Response)>, IMapFrom<Domain.Entities.LocalGovernment>
    {
        /// <summary>
        ///
        /// </summary>
        public string Id { get; set; }
    }
}