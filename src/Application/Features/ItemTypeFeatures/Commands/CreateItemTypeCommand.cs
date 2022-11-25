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
    public class CreateItemTypeCommand : IRequestHandler<CreateItemTypeRequest, (bool Succeed, string Message, CreateItemTypeResponse Response)>
    {
        private readonly IApplicationDbContext applicationDb;
        private readonly IMapper mapper;

        /// <summary>
        ///
        /// </summary>
        /// <param name="applicationDb"></param>
        /// <param name="mapper"></param>
        public CreateItemTypeCommand(IApplicationDbContext applicationDb, IMapper mapper)
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

        public async Task<(bool Succeed, string Message, CreateItemTypeResponse Response)> Handle(CreateItemTypeRequest request, CancellationToken cancellationToken)
        {
            var ItemType = mapper.Map<ItemType>(request);

            var itemTypeNameExist = await applicationDb.ItemTypes.FirstOrDefaultAsync(x => x.ItemTypeName.Equals(request.ItemTypeName), cancellationToken);
            if (itemTypeNameExist != null)
                return (false, "The Item Type with the name has already been created", null);
            //perform insert
            ItemType.DateCreated = DateTime.Now;
            ItemType.DateModified = DateTime.Now;
            ItemType.CreatedBy = "Test";
            ItemType.Status = true;

            await applicationDb.ItemTypes.AddAsync(ItemType, cancellationToken);

            await applicationDb.SaveChangesAsync(cancellationToken);

            // mapper can be used here
            var response = mapper.Map<CreateItemTypeResponse>(request);
            // return response object
            response.Id = ItemType.Id;
            return (true, "Item Type Created successfully", response);
        }
    }
}