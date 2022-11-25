using Application.Interfaces;
using Application.Request.LocalGovernment;
using Application.Response.LocalGovernment;
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
    public class CreateLocalGovernmentCommand : IRequestHandler<CreateLocalGovernmentRequest, (bool Succeed, string Message, CreateLocalGovernmentResponse Response)>
    {
        private readonly IApplicationDbContext applicationDb;
        private readonly IMapper mapper;

        /// <summary>
        ///
        /// </summary>
        /// <param name="applicationDb"></param>
        /// <param name="mapper"></param>
        public CreateLocalGovernmentCommand(IApplicationDbContext applicationDb, IMapper mapper)
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

        public async Task<(bool Succeed, string Message, CreateLocalGovernmentResponse Response)> Handle(CreateLocalGovernmentRequest request, CancellationToken cancellationToken)
        {
            var unit = mapper.Map<LocalGovernment>(request);

            var unitNameExist = await applicationDb.LocalGovernments.FirstOrDefaultAsync(x => x.Name.Equals(request.Name), cancellationToken);
            if (unitNameExist != null)
                return (false, "The Local Government with this name has already been created", null);
            //perform insert
            unit.DateCreated = DateTime.Now;
            await applicationDb.LocalGovernments.AddAsync(unit, cancellationToken);

            await applicationDb.SaveChangesAsync(cancellationToken);

            // mapper can be used here
            var response = mapper.Map<CreateLocalGovernmentResponse>(request);
            // return response object
            response.Id = unit.Id;
            return (true, "LocalGovernment Created successfully", response);
        }
    }
}