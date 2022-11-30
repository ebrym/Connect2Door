using Application.Interfaces;
using Application.Request.Country;
using Application.Response.Country;
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
    public class DeleteCountryCommand : IRequestHandler<DeleteCountryRequest, (bool Succeed, string Message, DeleteCountryResponse Response)>
    {
        private readonly IApplicationDbContext applicationDb;
        private readonly IMapper mapper;

        /// <summary>
        ///
        /// </summary>
        /// <param name="applicationDb"></param>
        /// <param name="mapper"></param>
        public DeleteCountryCommand(IApplicationDbContext applicationDb, IMapper mapper)
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

        public async Task<(bool Succeed, string Message, DeleteCountryResponse Response)> Handle(DeleteCountryRequest request, CancellationToken cancellationToken)
        {
            var country = await applicationDb.Countries.Where(u => u.Id == request.Id).FirstOrDefaultAsync();

            country.IsDeleted = true;
            applicationDb.Countries.Update(country);

            int saved = await applicationDb.SaveChangesAsync(cancellationToken);

            // mapper can be used here
            var response = new DeleteCountryResponse();
            // return response object
            response.Id = country.Id;

            if (saved > 0)
            {
                return (true, "Country Deleted successfully", response);
            }
            return (false, "There was a problem deleting the specified Country.", response);
        }
    }
}