using Application.Interfaces;
using Application.Request.State;
using Application.Response.State;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.UnitFeatures.Commands
{
    /// <summary>
    ///
    /// </summary>
    public class CreateStateCommand : IRequestHandler<CreateStateRequest, (bool Succeed, string Message, CreateStateResponse Response)>
    {
        private readonly IApplicationDbContext applicationDb;
        private readonly IMapper mapper;

        /// <summary>
        ///
        /// </summary>
        /// <param name="applicationDb"></param>
        /// <param name="mapper"></param>
        public CreateStateCommand(IApplicationDbContext applicationDb, IMapper mapper)
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

        public async Task<(bool Succeed, string Message, CreateStateResponse Response)> Handle(CreateStateRequest request, CancellationToken cancellationToken)
        {
            var state = mapper.Map<State>(request);

            var stateNameExist = await applicationDb.States.FirstOrDefaultAsync(x => x.Name.Equals(request.Name), cancellationToken);
            if (stateNameExist != null)
                return (false, "The Unit with this name has already been created", null);
            //perform insert
            state.DateCreated = DateTime.Now;
            await applicationDb.States.AddAsync(state, cancellationToken);

            await applicationDb.SaveChangesAsync(cancellationToken);

            // mapper can be used here
            var response = mapper.Map<CreateStateResponse>(request);
            // return response object
            response.Id = state.Id;
            return (true, "State Created successfully", response);
        }
    }
}