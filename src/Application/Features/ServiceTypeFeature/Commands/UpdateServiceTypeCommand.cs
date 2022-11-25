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
    public class UpdateServiceTypeCommand : IRequestHandler<UpdateServiceTypeRequest, (bool Succeed, string Message, UpdateServiceTypeResponse Response)>
    {
        private readonly IApplicationDbContext applicationDb;
        private readonly IMapper mapper;

        /// <summary>
        ///
        /// </summary>
        /// <param name="applicationDb"></param>
        /// <param name="mapper"></param>
        public UpdateServiceTypeCommand(IApplicationDbContext applicationDb, IMapper mapper)
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

        public async Task<(bool Succeed, string Message, UpdateServiceTypeResponse Response)> Handle(UpdateServiceTypeRequest request, CancellationToken cancellationToken)
        {
            var serviceType = mapper.Map<ServiceType>(request);

            var entity = await applicationDb.ServiceTypes.FindAsync(serviceType.Id);
            if (entity.Id == serviceType.Id)
            {
                if (entity.ServiceTypeName != serviceType.ServiceTypeName)
                {
                    var ServiceTypeNameExist = await applicationDb.ServiceTypes.FirstOrDefaultAsync(x => x.ServiceTypeName.Equals(request.ServiceTypeName), cancellationToken);
                    if (ServiceTypeNameExist != null)
                        return (false, "The Service Type with the name already exist", null);
                }
                entity.ServiceTypeName = serviceType.ServiceTypeName;
                entity.Status = serviceType.Status;

                entity.DateModified = DateTime.Now;
                await applicationDb.SaveChangesAsync(cancellationToken);
            }
            else
            {
                return (false, "The ServiceType can not be updated because it does not exist", null);
            }

            // mapper can be used here
            var response = mapper.Map<UpdateServiceTypeResponse>(request);
            response.Id = serviceType.Id;
            // return response object
            return (true, "ServiceType Updated successfully", response);
        }
    }
}