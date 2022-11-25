using Application.Interfaces;
using Application.Response.Country;
using MediatR;

namespace Application.Request.Country
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

    public class CreateCountryRequest : IRequest<(bool Succeed, string Message, CreateCountryResponse Response)>, IMapFrom<Domain.Entities.Country>
    {
        /// <summary>
        ///
        /// </summary>
        public string Name { get; set; }

        public string Code { get; set; }
    }
}