using Application.Interfaces;
using Application.Request.LocalGovernment;

namespace Application.Response.LocalGovernment
{
    /// <summary>
    ///
    /// </summary>
    public class CreateLocalGovernmentResponse : IMapFrom<CreateLocalGovernmentRequest>
    {
        /// <summary>
        ///
        /// </summary>
        public string Id { get; set; }
    }
}