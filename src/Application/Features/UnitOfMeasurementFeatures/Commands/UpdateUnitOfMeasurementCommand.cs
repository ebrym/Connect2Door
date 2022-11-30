using Application.Interfaces;
using Application.Request.UnitOfMeasurement;
using Application.Response.UnitOfMeasurement;

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
    public class UpdateUnitOfMeasurementCommand : IRequestHandler<UpdateUnitOfMeasurementRequest, (bool Succeed, string Message, UpdateUnitOfMeasurementResponse Response)>
    {
        private readonly IApplicationDbContext applicationDb;
        private readonly IMapper mapper;

        /// <summary>
        ///
        /// </summary>
        /// <param name="applicationDb"></param>
        /// <param name="mapper"></param>
        public UpdateUnitOfMeasurementCommand(IApplicationDbContext applicationDb, IMapper mapper)
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

        public async Task<(bool Succeed, string Message, UpdateUnitOfMeasurementResponse Response)> Handle(UpdateUnitOfMeasurementRequest request, CancellationToken cancellationToken)
        {
            var unit = mapper.Map<UnitOfMeasurement>(request);

            var entity = await applicationDb.UnitOfMeasurements.FindAsync(unit.Id);

            /* var unitNameExist = await applicationDb.UnitOfMeasurements.FirstOrDefaultAsync(x => x.Name.Equals(request.Name), cancellationToken);
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
            var response = mapper.Map<UpdateUnitOfMeasurementResponse>(request);
            response.Id = unit.Id;
            // return response object
            return (true, "Unit Updated successfully", response);
        }
    }
}