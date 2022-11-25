using Application.Interfaces;
using Application.Request.Company;
using Application.Response.Company;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.UnitFeatures.Commands
{
    /// <summary>
    ///
    /// </summary>
    public class DeleteCompanyCommand : IRequestHandler<DeleteCompanyRequest, (bool Succeed, string Message, DeleteCompanyResponse Response)>
    {
        private readonly IApplicationDbContext applicationDb;
        private readonly IMapper mapper;

        /// <summary>
        ///
        /// </summary>
        /// <param name="applicationDb"></param>
        /// <param name="mapper"></param>
        public DeleteCompanyCommand(IApplicationDbContext applicationDb, IMapper mapper)
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
        /// <exception cref="NotImplementedException"></exception>

        public async Task<(bool Succeed, string Message, DeleteCompanyResponse Response)> Handle(DeleteCompanyRequest request, CancellationToken cancellationToken)
        {
            var country = await applicationDb.Companies.Where(u => u.Id == request.Id).FirstOrDefaultAsync();
            if (country != null)
            {
                country.IsDeleted = true;
                // applicationDb.Countries.Update(country);

                int saved = await applicationDb.SaveChangesAsync(cancellationToken);

                // mapper can be used here
                var response = new DeleteCompanyResponse();
                // return response object
                response.Id = country.Id;

                if (saved > 0)
                {
                    return (true, "Company Deleted successfully", response);
                }
                return (false, "There was a problem deleting the specified Company.", response);
            }

            return (false, "Country not found", null);
        }
    }
}