using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SimuladorExitoAPI.Models.ModelConfigurations
{
    public class MilestoneConfiguration : IEntityTypeConfiguration<Milestone>
    {
        public void Configure(EntityTypeBuilder<Milestone> builder)
        {
            builder.ToTable("Milestone");
            builder
                .HasOne(m => m.Career)
                .WithMany(c => c.Milestones)
                .HasForeignKey(m => m.CareerId)
                .HasPrincipalKey(c => c.Id);
            builder
                .HasMany(m => m.Positions)
                .WithMany()
                .UsingEntity<MilestonePosition>(
                    e => e
                        .HasOne(mp => mp.Position)
                        .WithMany()
                        .HasForeignKey(mp => mp.PositionId)
                        .OnDelete(DeleteBehavior.NoAction),
                    e => e
                        .HasOne(mp => mp.Milestone)
                        .WithMany()
                        .HasForeignKey(mp => mp.MilestoneId)
                        .OnDelete(DeleteBehavior.NoAction)
                );
            builder.HasMany(m => m.Postgraduates)
                .WithMany()
                .UsingEntity<MilestonePostgraduate>(
                    e => e
                        .HasOne(mp => mp.Postgraduate)
                        .WithMany()
                        .HasForeignKey(mp => mp.PostgraduateId)
                        .OnDelete(DeleteBehavior.NoAction),
                    e => e
                        .HasOne(mp => mp.Milestone)
                        .WithMany()
                        .HasForeignKey(mp => mp.MilestoneId)
                        .OnDelete(DeleteBehavior.NoAction)
                );
        }
    }
}
