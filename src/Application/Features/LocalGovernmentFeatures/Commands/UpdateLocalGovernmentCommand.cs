using Application.Interfaces;
using Application.Request.LocalGovernment;
using Application.Response.LocalGovernment;

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
    public class UpdateLocalGovernmentCommand : IRequestHandler<UpdateLocalGovernmentRequest, (bool Succeed, string Message, UpdateLocalGovernmentResponse Response)>
    {
        private readonly IApplicationDbContext applicationDb;
        private readonly IMapper mapper;

        /// <summary>
        ///
        /// </summary>
        /// <param name="applicationDb"></param>
        /// <param name="mapper"></param>
        public UpdateLocalGovernmentCommand(IApplicationDbContext applicationDb, IMapper mapper)
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

        public async Task<(bool Succeed, string Message, UpdateLocalGovernmentResponse Response)> Handle(UpdateLocalGovernmentRequest request, CancellationToken cancellationToken)
        {
            var localGovernment = mapper.Map<LocalGovernment>(request);

            var entity = await applicationDb.LocalGovernments.FindAsync(localGovernment.Id);

            /* var unitNameExist = await applicationDb.LocalGovernments.FirstOrDefaultAsync(x => x.Name.Equals(request.Name), cancellationToken);
             if (unitNameExist != null)
                 return (false, "The Unit with this name has already been created", null);*/

            if (entity.Id == localGovernment.Id)
            {
                entity.Name = localGovernment.Name;
                entity.Code = localGovernment.Code;
                entity.StateId = localGovernment.StateId;

                await applicationDb.SaveChangesAsync(cancellationToken);
            }
            else
            {
                return (false, "The Local Government does not exist", null);
            }

            // mapper can be used here
            var response = mapper.Map<UpdateLocalGovernmentResponse>(request);
            response.Id = localGovernment.Id;
            // return response object
            return (true, "Local Government Updated successfully", response);
        }
    }
}