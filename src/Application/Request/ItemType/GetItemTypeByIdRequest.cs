using Application.Response.ItemType;
using MediatR;

namespace Application.Request.ItemType
{
    /// <summary>
    ///
    /// </summary>
    public class GetItemTypeByIdRequest : IRequest<GetAllItemTypeByIdResponse>
    {
        /// <summary>
        /// Id
        /// </summary>
        /// <value>
        /// The Id
        /// </value>
        public string Id { get; set; }
    }
}