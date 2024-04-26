using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SimuladorExitoAPI.Models.ModelConfigurations
{
    public class PostgraduateConfiguration : IEntityTypeConfiguration<Postgraduate>
    {
        public void Configure(EntityTypeBuilder<Postgraduate> builder)
        {
            builder.ToTable("Postgraduate");
            builder.Property(p => p.PostLevel).HasColumnType("VARCHAR(20)").HasConversion<string>();
            builder
                .HasOne(p => p.Career)
                .WithMany(c => c.Postgraduates)
                .HasForeignKey(p => p.CareerId)
                .HasPrincipalKey(c => c.Id);

        }
    }
}
