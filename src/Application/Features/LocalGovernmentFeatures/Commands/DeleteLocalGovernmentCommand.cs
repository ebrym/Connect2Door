using Application.Interfaces;
using Application.Request.LocalGovernment;
using Application.Response.LocalGovernment;
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
    public class DeleteLocalGovernmentCommand : IRequestHandler<DeleteLocalGovernmentRequest, (bool Succeed, string Message, DeleteLocalGovernmentResponse Response)>
    {
        private readonly IApplicationDbContext applicationDb;
        private readonly IMapper mapper;

        /// <summary>
        ///
        /// </summary>
        /// <param name="applicationDb"></param>
        /// <param name="mapper"></param>
        public DeleteLocalGovernmentCommand(IApplicationDbContext applicationDb, IMapper mapper)
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

        public async Task<(bool Succeed, string Message, DeleteLocalGovernmentResponse Response)> Handle(DeleteLocalGovernmentRequest request, CancellationToken cancellationToken)
        {
            var unitOfMeasurement = await applicationDb.LocalGovernments.Where(u => u.Id == request.Id).FirstOrDefaultAsync();

            unitOfMeasurement.IsDeleted = true;
            applicationDb.LocalGovernments.Update(unitOfMeasurement);

            int saved = await applicationDb.SaveChangesAsync(cancellationToken);

            // mapper can be used here
            var response = new DeleteLocalGovernmentResponse();
            // return response object
            response.Id = unitOfMeasurement.Id;

            if (saved > 0)
            {
                return (true, "Local Government Deleted successfully", response);
            }
            return (false, "There was a problem deleting the specified LocalGovernment.", response);
        }
    }
}