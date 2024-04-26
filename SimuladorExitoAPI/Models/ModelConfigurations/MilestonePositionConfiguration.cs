using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SimuladorExitoAPI.Models.ModelConfigurations
{
    public class MilestonePositionConfiguration : IEntityTypeConfiguration<MilestonePosition>
    {
        public void Configure(EntityTypeBuilder<MilestonePosition> builder)
        {
            builder.HasKey("MilestoneId", "PositionId");
        }
    }
}
