using Application.Interfaces;
using Application.Request.Unit;
using Application.Response.Unit;
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
    public class DeleteUnitCommand : IRequestHandler<DeleteUnitRequest, (bool Succeed, string Message, DeleteUnitResponse Response)>
    {
        private readonly IApplicationDbContext applicationDb;
        private readonly IMapper mapper;

        /// <summary>
        ///
        /// </summary>
        /// <param name="applicationDb"></param>
        /// <param name="mapper"></param>
        public DeleteUnitCommand(IApplicationDbContext applicationDb, IMapper mapper)
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

        public async Task<(bool Succeed, string Message, DeleteUnitResponse Response)> Handle(DeleteUnitRequest request, CancellationToken cancellationToken)
        {
            var unitOfMeasurement = await applicationDb.Units.Where(u => u.Id == request.Id).FirstOrDefaultAsync();

            unitOfMeasurement.IsDeleted = true;
            applicationDb.Units.Update(unitOfMeasurement);

            int saved = await applicationDb.SaveChangesAsync(cancellationToken);

            // mapper can be used here
            var response = new DeleteUnitResponse();
            // return response object
            response.Id = unitOfMeasurement.Id;

            if (saved > 0)
            {
                return (true, "Unit Of Measurement Deleted successfully", response);
            }
            return (false, "There was a problem deleting the specified Unit Of Measurement.", response);
        }
    }
}