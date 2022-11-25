using Application.Interfaces;
using Application.Request.Company;
using Application.Response.Company;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.UnitFeatures.Commands
{
    /// <summary>
    ///
    /// </summary>
    public class CreateCompanyCommand : IRequestHandler<CreateCompanyRequest, (bool Succeed, string Message, CreateCompanyResponse Response)>
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
        /// <param name="mediator"></param>
        /// <param name="uploadService"></param>
        public CreateCompanyCommand(IApplicationDbContext applicationDb, IMapper mapper, IMediator mediator, IUploadService uploadService)
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

        public async Task<(bool Succeed, string Message, CreateCompanyResponse Response)> Handle(CreateCompanyRequest request, CancellationToken cancellationToken)
        {
            var company = mapper.Map<Company>(request);

            var uploadsFolder = @"Uploads\Companies\UploadedFiles";

            var banner = await uploadService.UploadToServer(request.UploadBanner, uploadsFolder);
            var logo = await uploadService.UploadToServer(request.UploadLogo, uploadsFolder);

            var companyNameExist = await applicationDb.Companies.FirstOrDefaultAsync(x => x.Name.Equals(request.Name), cancellationToken);
            if (companyNameExist != null)
                return (false, "The Company with this name has already been created", null);
            //perform insert
            company.Logo = logo;
            company.Banner = banner;
            company.DateCreated = DateTime.Now;
            await applicationDb.Companies.AddAsync(company, cancellationToken);

            await applicationDb.SaveChangesAsync(cancellationToken);

            // mapper can be used here
            var response = mapper.Map<CreateCompanyResponse>(request);
            // return response object
            response.Id = company.Id;
            return (true, "Company Created successfully", response);
        }
    }
}