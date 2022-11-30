using Application.Interfaces;
using Application.Request.Unit;
using Application.Response.Unit;
using AutoMapper;
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
    public class CreateUnitCommand : IRequestHandler<CreateUnitRequest, (bool Succeed, string Message, CreateUnitResponse Response)>
    {
        private readonly IApplicationDbContext applicationDb;
        private readonly IMapper mapper;

        /// <summary>
        ///
        /// </summary>
        /// <param name="applicationDb"></param>
        /// <param name="mapper"></param>
        public CreateUnitCommand(IApplicationDbContext applicationDb, IMapper mapper)
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

        public async Task<(bool Succeed, string Message, CreateUnitResponse Response)> Handle(CreateUnitRequest request, CancellationToken cancellationToken)
        {
            var unit = mapper.Map<Domain.Entities.Unit>(request);

            var unitNameExist = await applicationDb.Units.FirstOrDefaultAsync(x => x.Name.Equals(request.Name), cancellationToken);
            if (unitNameExist != null)
                return (false, "The Unit with this name has already been created", null);
            //perform insert
            unit.DateCreated = DateTime.Now;
            await applicationDb.Units.AddAsync(unit, cancellationToken);

            await applicationDb.SaveChangesAsync(cancellationToken);

            // mapper can be used here
            var response = mapper.Map<CreateUnitResponse>(request);
            // return response object
            response.Id = unit.Id;
            return (true, "Unit Created successfully", response);
        }
    }
}