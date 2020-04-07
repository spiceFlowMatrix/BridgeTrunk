using Bridge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class ManagementInfoConfiguration: IEntityTypeConfiguration<ManagementInfo>
    {
        public void Configure(EntityTypeBuilder<ManagementInfo> builder)
        {
            builder.HasKey(e => e.Id);
        }
        
    }
}