using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SimuladorExitoAPI.Models.ModelConfigurations
{
    public class CareerConfiguration : IEntityTypeConfiguration<Career>
    {
        public void Configure(EntityTypeBuilder<Career> builder)
        {
            builder.ToTable("Career");
            builder.HasIndex(c => c.Slug).IsUnique();
        }
    }
}
