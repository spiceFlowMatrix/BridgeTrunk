using Bridge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class AgentCategoryConfiguration: IEntityTypeConfiguration<AgentCategory>
    {
        public void Configure(EntityTypeBuilder<AgentCategory> builder)
        {
            builder.HasKey(e => e.Id);
        }
    }
}
