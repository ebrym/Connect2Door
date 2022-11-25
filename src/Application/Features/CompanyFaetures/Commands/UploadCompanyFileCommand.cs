using Application.Interfaces;
using Application.Request.Company;
using Application.Response.Company;
using AutoMapper;
using Domain.Common;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.UnitFeatures.Commands
{
    /// <summary>
    ///
    /// </summary>
    public class UploadCompanyCommand : IRequestHandler<UploadCompanyFileRequest, (bool Succeed, string Message, GetCompanyByIdResponse Response)>
    {
        private readonly IApplicationDbContext applicationDb;
        private readonly IMapper mapper;
        private readonly IMediator mediator;
        private readonly IUploadService uploadService;

        /// <summary>
        ///
        /// </summary>
        /// <param name="applicationDb"></param>
        /// <param name="mapper"></param>
        public UploadCompanyCommand(IApplicationDbContext applicationDb, IMapper mapper, IMediator mediator, IUploadService uploadService)
        {
            this.applicationDb = applicationDb;
            this.mapper = mapper;
            this.mediator = mediator;
            this.uploadService = uploadService;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>

        public async Task<(bool Succeed, string Message, UpdateCompanyResponse Response)> Handle(UpdateCompanyRequest request, CancellationToken cancellationToken)
        {
            var company = mapper.Map<Company>(request);

            var entity = await applicationDb.Companies.FindAsync(company.Id);

            /* var companyNameExist = await applicationDb.Companys.FirstOrDefaultAsync(x => x.Name.Equals(request.Name), cancellationToken);
             if (companyNameExist != null)
                 return (false, "The Unit with this name has already been created", null);*/

            if (entity.Id == company.Id)
            {
                entity.Name = company.Name;
                entity.CountryId = company.CountryId;
                entity.StateId = company.StateId;
                entity.Address = company.Address;
                entity.Banner = company.Banner;
                entity.Email = company.Email;
                entity.Logo = company.Logo;
                entity.Website = company.Website;

                await applicationDb.SaveChangesAsync(cancellationToken);
            }
            else
            {
                return (false, "The Company does not exist", null);
            }

            // mapper can be used here
            var response = mapper.Map<UpdateCompanyResponse>(request);
            response.Id = company.Id;
            // return response object
            return (true, "Company Updated successfully", response);
        }

        public async Task<(bool Succeed, string Message, GetCompanyByIdResponse Response)> Handle(UploadCompanyFileRequest request, CancellationToken cancellationToken)
        {
            // var uploadsFolder = @"Uploads\Companies\UploadedFiles";
            var uploadedFilePath = await uploadService.UploadAsBase64String(request.FormFile);

            var company = await applicationDb.Companies.Where(c => c.Id == request.Id && c.IsDeleted == false)
                .FirstOrDefaultAsync();
            if (company != null)
            {
                if (request.CompanyFileType == CompanyFileType.Banner)
                {
                    company.Banner = uploadedFilePath;
                }
                if (request.CompanyFileType == CompanyFileType.Logo)
                {
                    company.Logo = uploadedFilePath;
                }

                applicationDb.Companies.Update(company);
                await applicationDb.SaveChangesAsync();
                // mapper can be used here
                var response = mapper.Map<GetCompanyByIdResponse>(company);
                response.Id = company.Id;
                // return response object
                return (true, "Company Updated successfully", response);
            }
            return (false, "Invalid company id specified. Upload failed", null);
        }
    }
}