using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SimuladorExitoAPI.Models.ModelConfigurations
{
    public class MilestonePostgraduateConfiguration : IEntityTypeConfiguration<MilestonePostgraduate>
    {
        public void Configure(EntityTypeBuilder<MilestonePostgraduate> builder)
        {
            builder.HasKey("MilestoneId", "PostgraduateId");
        }
    }
}
