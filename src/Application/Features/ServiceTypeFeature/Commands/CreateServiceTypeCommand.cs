using Application.Interfaces;
using Application.Request.ServiceType;
using Application.Response.ServiceType;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.ServiceTypeFeature.Commands
{
    /// <summary>
    ///
    /// </summary>
    public class CreateServiceTypeCommand : IRequestHandler<CreateServiceTypeRequest, (bool Succeed, string Message, CreateServiceTypeResponse Response)>
    {
        private readonly IApplicationDbContext applicationDb;
        private readonly IMapper mapper;

        /// <summary>
        ///
        /// </summary>
        /// <param name="applicationDb"></param>
        /// <param name="mapper"></param>
        public CreateServiceTypeCommand(IApplicationDbContext applicationDb, IMapper mapper)
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

        public async Task<(bool Succeed, string Message, CreateServiceTypeResponse Response)> Handle(CreateServiceTypeRequest request, CancellationToken cancellationToken)
        {
            var ServiceType = mapper.Map<ServiceType>(request);

            var ServiceTypeNameExist = await applicationDb.ServiceTypes.FirstOrDefaultAsync(x => x.ServiceTypeName.Equals(request.ServiceTypeName), cancellationToken);
            if (ServiceTypeNameExist != null)
                return (false, "The Service Type with the name has already been created", null);
            //perform insert
            ServiceType.DateCreated = DateTime.Now;
            ServiceType.DateModified = DateTime.Now;
            ServiceType.CreatedBy = "Test";
            ServiceType.Status = true;

            await applicationDb.ServiceTypes.AddAsync(ServiceType, cancellationToken);

            await applicationDb.SaveChangesAsync(cancellationToken);

            // mapper can be used here
            var response = mapper.Map<CreateServiceTypeResponse>(request);
            // return response object
            response.Id = ServiceType.Id;
            return (true, "Service Type Created successfully", response);
        }
    }
}