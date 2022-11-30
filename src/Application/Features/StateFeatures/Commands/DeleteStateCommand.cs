using Application.Interfaces;
using Application.Request.State;
using Application.Response.State;
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
    public class DeleteStateCommand : IRequestHandler<DeleteStateRequest, (bool Succeed, string Message, DeleteStateResponse Response)>
    {
        private readonly IApplicationDbContext applicationDb;
        private readonly IMapper mapper;

        /// <summary>
        ///
        /// </summary>
        /// <param name="applicationDb"></param>
        /// <param name="mapper"></param>
        public DeleteStateCommand(IApplicationDbContext applicationDb, IMapper mapper)
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

        public async Task<(bool Succeed, string Message, DeleteStateResponse Response)> Handle(DeleteStateRequest request, CancellationToken cancellationToken)
        {
            var state = await applicationDb.States.Where(u => u.Id == request.Id).FirstOrDefaultAsync();

            state.IsDeleted = true;
            applicationDb.States.Update(state);

            int saved = await applicationDb.SaveChangesAsync(cancellationToken);

            // mapper can be used here
            var response = new DeleteStateResponse();
            // return response object
            response.Id = state.Id;

            if (saved > 0)
            {
                return (true, "State Deleted successfully", response);
            }
            return (false, "There was a problem deleting the specified State.", response);
        }
    }
}