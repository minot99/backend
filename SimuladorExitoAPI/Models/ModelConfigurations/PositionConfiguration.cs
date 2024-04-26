using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SimuladorExitoAPI.Models.ModelConfigurations
{
    public class PositionConfiguration : IEntityTypeConfiguration<Position>
    {
        public void Configure(EntityTypeBuilder<Position> builder)
        {
            builder.ToTable("Position");
            builder
                .HasOne(p => p.Carrer)
                .WithMany(c => c.Positions)
                .HasForeignKey(p => p.CarrerId)
                .HasPrincipalKey(c => c.Id);
            builder
                .Property(p => p.Sector)
                .HasColumnType("VARCHAR(20)")
                .HasConversion<string>();
        }
    }
}
