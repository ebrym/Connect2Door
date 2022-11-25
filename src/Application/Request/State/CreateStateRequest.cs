using Application.Interfaces;
using Application.Response.State;
using MediatR;

namespace Application.Request.State
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

    public class CreateStateRequest : IRequest<(bool Succeed, string Message, CreateStateResponse Response)>, IMapFrom<Domain.Entities.State>
    {
        /// <summary>
        ///
        /// </summary>
        public string Name { get; set; }

        public string Code { get; set; }

        public string CountryId { get; set; }
    }
}