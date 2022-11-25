using Application.Interfaces;
using Application.Request.ItemType;
using Application.Response.ItemType;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.ItemTypeFeatures.Commands
{
    /// <summary>
    ///
    /// </summary>
    public class UpdateItemTypeCommand : IRequestHandler<UpdateItemTypeRequest, (bool Succeed, string Message, UpdateItemTypeResponse Response)>
    {
        private readonly IApplicationDbContext applicationDb;
        private readonly IMapper mapper;

        /// <summary>
        ///
        /// </summary>
        /// <param name="applicationDb"></param>
        /// <param name="mapper"></param>
        public UpdateItemTypeCommand(IApplicationDbContext applicationDb, IMapper mapper)
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

        public async Task<(bool Succeed, string Message, UpdateItemTypeResponse Response)> Handle(UpdateItemTypeRequest request, CancellationToken cancellationToken)
        {
            var itemType = mapper.Map<ItemType>(request);

            var entity = await applicationDb.ItemTypes.FirstOrDefaultAsync(x => x.Id.Equals(request.ItemTypeName), cancellationToken);
            if (entity.Id == itemType.Id)
            {
                if (entity.ItemTypeName != itemType.ItemTypeName)
                {
                    var itemTypeNameExist = await applicationDb.ItemTypes.FirstOrDefaultAsync(x => x.ItemTypeName.Equals(request.ItemTypeName), cancellationToken);
                    if (itemTypeNameExist != null)
                        return (false, "The Item Type with the name already exist ", null);
                }
                entity.ItemTypeName = itemType.ItemTypeName;
                entity.Status = itemType.Status;
                entity.ModifiedBy = "Test";
                entity.DateModified = DateTime.Now;

                await applicationDb.SaveChangesAsync(cancellationToken);
            }
            else
            {
                return (false, "The ItemType can not be updated because it does not exist", null);
            }

            // mapper can be used here
            var response = mapper.Map<UpdateItemTypeResponse>(request);
            response.Id = itemType.Id;
            // return response object
            return (true, "ItemType Updated successfully", response);
        }
    }
}