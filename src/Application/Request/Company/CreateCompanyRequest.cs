using Application.Interfaces;
using Application.Response.Company;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Request.Company
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

    public class CreateCompanyRequest : IRequest<(bool Succeed, string Message, CreateCompanyResponse Response)>, IMapFrom<Domain.Entities.Company>
    {
        /// <summary>
        ///
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the website.
        /// </summary>
        /// <value>
        /// The website.
        /// </value>
        public string Website { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        /// <value>
        /// The address.
        /// </value>
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets the logo.
        /// </summary>
        /// <value>
        /// The logo.
        /// </value>
        public IFormFile UploadLogo { get; set; }

        /// <summary>
        /// Gets or sets the banner.
        /// </summary>
        /// <value>
        /// The banner.
        /// </value>
        public IFormFile UploadBanner { get; set; }

        /// <summary>
        /// Gets or sets the country identifier.
        /// </summary>
        /// <value>
        /// The country identifier.
        /// </value>
        public string CountryId { get; set; }

        /// <summary>
        /// Gets or sets the state identifier.
        /// </summary>
        /// <value>
        /// The state identifier.
        /// </value>
        public string StateId { get; set; }

        /// <summary>
        /// Gets or sets the logo.
        /// </summary>
        /// <value>
        /// The logo.
        /// </value>
        public string Logo { get; set; }

        /// <summary>
        /// Gets or sets the banner.
        /// </summary>
        /// <value>
        /// The banner.
        /// </value>
        public string Banner { get; set; }
    }
}