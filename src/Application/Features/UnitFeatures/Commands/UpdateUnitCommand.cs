using Application.Interfaces;
using Application.Request.Unit;
using Application.Response.Unit;

using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.UnitFeatures.Commands
{
    /// <summary>
    ///
    /// </summary>
    public class UpdateUnitCommand : IRequestHandler<UpdateUnitRequest, (bool Succeed, string Message, UpdateUnitResponse Response)>
    {
        private readonly IApplicationDbContext applicationDb;
        private readonly IMapper mapper;

        /// <summary>
        ///
        /// </summary>
        /// <param name="applicationDb"></param>
        /// <param name="mapper"></param>
        public UpdateUnitCommand(IApplicationDbContext applicationDb, IMapper mapper)
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

        public async Task<(bool Succeed, string Message, UpdateUnitResponse Response)> Handle(UpdateUnitRequest request, CancellationToken cancellationToken)
        {
            var unit = mapper.Map<Domain.Entities.Unit>(request);

            var entity = await applicationDb.Units.FindAsync(unit.Id);

            /* var unitNameExist = await applicationDb.Units.FirstOrDefaultAsync(x => x.Name.Equals(request.Name), cancellationToken);
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
                return (false, "The Unit does not exist", null);
            }

            // mapper can be used here
            var response = mapper.Map<UpdateUnitResponse>(request);
            response.Id = unit.Id;
            // return response object
            return (true, "Unit Updated successfully", response);
        }
    }
}