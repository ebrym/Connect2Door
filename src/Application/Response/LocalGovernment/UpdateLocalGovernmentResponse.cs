using Application.Interfaces;
using Application.Request.LocalGovernment;

namespace Application.Response.LocalGovernment
{
    /// <summary>
    ///
    /// </summary>
    /// <seealso >
    /// <Cref>
    /// Application.Interfaces.IMapFrom{Application.Request.Unit.UpdateUnitRequest}
    /// </Cref>
    /// </seealso>
    public class UpdateLocalGovernmentResponse : IMapFrom<UpdateLocalGovernmentRequest>
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public string Id { get; set; }
    }
}