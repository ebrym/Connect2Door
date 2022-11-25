using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    /// <summary>
    ///
    /// </summary>
    /// <seealso>
    ///     <cref>Microsoft.EntityFrameworkCore.IEntityTypeConfiguration{Domain.Entities.Settings}</cref>
    /// </seealso>
    public class SettingsConfiguration : IEntityTypeConfiguration<Settings>
    {
        /// <summary>
        /// Configures the entity of type <typeparamref>
        ///     <name>TEntity</name>
        /// </typeparamref>
        /// .
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity type.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void Configure(EntityTypeBuilder<Settings> builder)
        {
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.AssetIdPrefix).HasDefaultValue("ASS-ID");
            builder.Property(x => x.AssetIdLength).HasDefaultValue(10);

            builder.HasData(new Settings() { AssetIdLength = 10, AssetIdPrefix = "ASS-ID" });
        }
    }
}