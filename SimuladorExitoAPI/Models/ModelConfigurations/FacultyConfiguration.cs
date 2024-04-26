using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SimuladorExitoAPI.Models.ModelConfigurations
{
    public class FacultyConfiguration : IEntityTypeConfiguration<Faculty>
    {
        public void Configure(EntityTypeBuilder<Faculty> builder)
        {
            builder.ToTable("Faculty");
            builder
                .HasMany(f => f.Careers)
                .WithOne(c => c.Faculty)
                .HasForeignKey(c => c.FacultyId)
                .HasPrincipalKey(f => f.Id);
        }
    }
}
