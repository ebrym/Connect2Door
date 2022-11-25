using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    /// <summary>
    ///
    /// </summary>
    public class CounterMap : IEntityTypeConfiguration<Counter>
    {
        /// <summary>
        /// Configures the entity of type <typeparamref>
        ///     <name>TEntity</name>
        /// </typeparamref>
        /// .
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity type.</param>
        public void Configure(EntityTypeBuilder<Counter> builder)
        {
            builder.Property(x => x.LastNumber).ValueGeneratedOnAdd();
            builder.Property(x => x.LastNumber).HasDefaultValue(0);
        }
    }
}