using Application.Interfaces;
using Application.Request.ItemType;

namespace Application.Response.ItemType
{
    /// <summary>
    ///
    /// </summary>
    public class CreateItemTypeResponse : IMapFrom<CreateItemTypeRequest>
    {
        // <summary>
        ///
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string ItemTypeName { get; set; }
    }
}