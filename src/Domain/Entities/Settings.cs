using Domain.Common;

namespace Domain.Entities
{
    /// <summary>
    ///
    /// </summary>
    /// <seealso cref="Domain.Common.BaseEntity" />
    public class Settings : BaseEntity
    {
        /// <summary>
        /// Gets or sets the asset identifier prefix.
        /// </summary>
        /// <value>
        /// The asset identifier prefix.
        /// </value>
        public string AssetIdPrefix { get; set; }

        /// <summary>
        /// Gets or sets the length of the asset identifier.
        /// </summary>
        /// <value>
        /// The length of the asset identifier.
        /// </value>
        public int AssetIdLength { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [allow asset approval].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [allow asset approval]; otherwise, <c>false</c>.
        /// </value>
        public bool AllowAssetApproval { get; set; }
    }
}