using Application.Interfaces;
using Application.Response.Company;
using Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Request.Company
{
    public class UploadCompanyFileRequest : IRequest<(bool Succeed, string Message, GetCompanyByIdResponse Response)>, IMapFrom<Domain.Entities.Company>
    {
        /// <summary>
        /// Gets or sets the comapny identifier.
        /// </summary>
        /// <value>
        /// The company identifier.
        /// </value>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the form file.
        /// </summary>
        /// <value>
        /// The form file.
        /// </value>
        public IFormFile FormFile { get; set; }

        public CompanyFileType CompanyFileType { get; set; }
    }
}