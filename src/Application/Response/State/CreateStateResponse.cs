using Application.Interfaces;
using Application.Request.State;

namespace Application.Response.State
{
    /// <summary>
    ///
    /// </summary>
    public class CreateStateResponse : IMapFrom<CreateStateRequest>
    {
        /// <summary>
        ///
        /// </summary>
        public string Id { get; set; }
    }
}