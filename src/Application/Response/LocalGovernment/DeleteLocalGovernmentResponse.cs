using Application.Interfaces;
using Application.Request.LocalGovernment;

namespace Application.Response.LocalGovernment
{
    /// <summary>
    ///
    /// </summary>
    public class DeleteLocalGovernmentResponse : IMapFrom<CreateLocalGovernmentRequest>
    {
        /// <summary>
        ///
        /// </summary>
        public string Id { get; set; }
    }
}