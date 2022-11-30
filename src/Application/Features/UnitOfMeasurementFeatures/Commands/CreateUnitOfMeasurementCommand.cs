using Application.Interfaces;
using Application.Request.UnitOfMeasurement;
using Application.Response.UnitOfMeasurement;
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
    public class CreateUnitOfMeasurementCommand : IRequestHandler<CreateUnitOfMeasurementRequest, (bool Succeed, string Message, CreateUnitOfMeasurementResponse Response)>
    {
        private readonly IApplicationDbContext applicationDb;
        private readonly IMapper mapper;

        /// <summary>
        ///
        /// </summary>
        /// <param name="applicationDb"></param>
        /// <param name="mapper"></param>
        public CreateUnitOfMeasurementCommand(IApplicationDbContext applicationDb, IMapper mapper)
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

        public async Task<(bool Succeed, string Message, CreateUnitOfMeasurementResponse Response)> Handle(CreateUnitOfMeasurementRequest request, CancellationToken cancellationToken)
        {
            var unit = mapper.Map<UnitOfMeasurement>(request);

            var unitNameExist = await applicationDb.UnitOfMeasurements.FirstOrDefaultAsync(x => x.Name.Equals(request.Name), cancellationToken);
            if (unitNameExist != null)
                return (false, "The Unit with this name has already been created", null);
            //perform insert
            unit.DateCreated = DateTime.Now;
            await applicationDb.UnitOfMeasurements.AddAsync(unit, cancellationToken);

            await applicationDb.SaveChangesAsync(cancellationToken);

            // mapper can be used here
            var response = mapper.Map<CreateUnitOfMeasurementResponse>(request);
            // return response object
            response.Id = unit.Id;
            return (true, "Unit Created successfully", response);
        }
    }
}