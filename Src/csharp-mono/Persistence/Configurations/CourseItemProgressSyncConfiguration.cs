using Bridge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class CourseItemProgressSyncConfiguration: IEntityTypeConfiguration<CourseItemProgressSync>
    {
        public void Configure(EntityTypeBuilder<CourseItemProgressSync> builder)
        {
            builder.HasKey(e => e.Id);
        }
        
    }
}