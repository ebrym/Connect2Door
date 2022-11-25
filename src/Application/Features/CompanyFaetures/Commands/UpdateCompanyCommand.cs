using Application.Interfaces;
using Application.Request.Company;
using Application.Response.Company;

using AutoMapper;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.UnitFeatures.Commands
{
    /// <summary>
    ///
    /// </summary>
    public class UpdateCompanyCommand : IRequestHandler<UpdateCompanyRequest, (bool Succeed, string Message, UpdateCompanyResponse Response)>
    {
        private readonly IApplicationDbContext applicationDb;
        private readonly IMapper mapper;

        /// <summary>
        ///
        /// </summary>
        /// <param name="applicationDb"></param>
        /// <param name="mapper"></param>
        public UpdateCompanyCommand(IApplicationDbContext applicationDb, IMapper mapper)
        {
            this.applicationDb = applicationDb;
            this.mapper = mapper;
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
    }
}