using Application.Interfaces;
using Application.Request.Unit;

namespace Application.Response.Unit
{
    /// <summary>
    ///
    /// </summary>
    public class DeleteUnitResponse : IMapFrom<CreateUnitRequest>
    {
        /// <summary>
        ///
        /// </summary>
        public string Id { get; set; }
    }
}