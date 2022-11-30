using Application.Interfaces;
using Application.Request.State;
using Application.Response.State;

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
    public class UpdateStateCommand : IRequestHandler<UpdateStateRequest, (bool Succeed, string Message, UpdateStateResponse Response)>
    {
        private readonly IApplicationDbContext applicationDb;
        private readonly IMapper mapper;

        /// <summary>
        ///
        /// </summary>
        /// <param name="applicationDb"></param>
        /// <param name="mapper"></param>
        public UpdateStateCommand(IApplicationDbContext applicationDb, IMapper mapper)
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

        public async Task<(bool Succeed, string Message, UpdateStateResponse Response)> Handle(UpdateStateRequest request, CancellationToken cancellationToken)
        {
            var state = mapper.Map<State>(request);

            var entity = await applicationDb.States.FindAsync(state.Id);

            /* var unitNameExist = await applicationDb.States.FirstOrDefaultAsync(x => x.Name.Equals(request.Name), cancellationToken);
             if (unitNameExist != null)
                 return (false, "The Unit with this name has already been created", null);*/

            if (entity.Id == state.Id)
            {
                entity.Name = state.Name;
                entity.Code = state.Code;
                entity.CountryId = state.CountryId;

                await applicationDb.SaveChangesAsync(cancellationToken);
            }
            else
            {
                return (false, "The State does not exist", null);
            }

            // mapper can be used here
            var response = mapper.Map<UpdateStateResponse>(request);
            response.Id = state.Id;
            // return response object
            return (true, "State Updated successfully", response);
        }
    }
}