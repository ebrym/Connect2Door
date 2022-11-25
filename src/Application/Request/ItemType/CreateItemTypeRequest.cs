using Application.Interfaces;
using Application.Response.ItemType;
using MediatR;

namespace Application.Request.ItemType
{
    /// <summary>
    ///
    /// </summary>
    public class CreateItemTypeRequest : IRequest<(bool Succeed, string Message, CreateItemTypeResponse Response)>, IMapFrom<Domain.Entities.ItemType>
    {
        /// <summary>
        /// ItemType
        /// </summary>
        /// <value>
        /// The Item Type Name
        /// </value>
        public string ItemTypeName { get; set; }

        ///// Gets or sets the Status.
        ///// </summary>
        ///// <value>
        ///// The Status
        ///// </value>
        ////public bool Status { get; set; }
    }
}