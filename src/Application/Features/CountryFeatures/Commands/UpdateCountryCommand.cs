using Application.Interfaces;
using Application.Request.Country;
using Application.Response.Country;

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
    public class UpdateCountryCommand : IRequestHandler<UpdateCountryRequest, (bool Succeed, string Message, UpdateCountryResponse Response)>
    {
        private readonly IApplicationDbContext applicationDb;
        private readonly IMapper mapper;

        /// <summary>
        ///
        /// </summary>
        /// <param name="applicationDb"></param>
        /// <param name="mapper"></param>
        public UpdateCountryCommand(IApplicationDbContext applicationDb, IMapper mapper)
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

        public async Task<(bool Succeed, string Message, UpdateCountryResponse Response)> Handle(UpdateCountryRequest request, CancellationToken cancellationToken)
        {
            var unit = mapper.Map<Country>(request);

            var entity = await applicationDb.Countries.FindAsync(unit.Id);

            /* var unitNameExist = await applicationDb.Countrys.FirstOrDefaultAsync(x => x.Name.Equals(request.Name), cancellationToken);
             if (unitNameExist != null)
                 return (false, "The Unit with this name has already been created", null);*/

            if (entity.Id == unit.Id)
            {
                entity.Name = unit.Name;
                entity.Code = unit.Code;

                await applicationDb.SaveChangesAsync(cancellationToken);
            }
            else
            {
                return (false, "The Country does not exist", null);
            }

            // mapper can be used here
            var response = mapper.Map<UpdateCountryResponse>(request);
            response.Id = unit.Id;
            // return response object
            return (true, "Country Updated successfully", response);
        }
    }
}