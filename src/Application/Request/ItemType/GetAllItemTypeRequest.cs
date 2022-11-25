using Application.Response.ItemType;
using MediatR;
using System.Collections.Generic;

namespace Application.Request.ItemType
{
    /// <summary>
    ///
    /// </summary>
    public class GetAllItemTypeRequest : IRequest<List<GetAllItemTypeResponse>>
    {
    }
}