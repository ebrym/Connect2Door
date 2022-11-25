using Application.Interfaces;
using Application.Request.ItemType;

namespace Application.Response.ItemType
{
    /// <summary>
    ///
    /// </summary>
    public class UpdateItemTypeResponse : IMapFrom<UpdateItemTypeRequest>
    {
        /// <summary>
        /// vendor id
        /// </summary>
        public string Id { get; set; }
    }
}