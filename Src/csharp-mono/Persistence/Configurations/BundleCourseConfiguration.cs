using Bridge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class BundleCourseConfiguration: IEntityTypeConfiguration<BundleCourse>
    {
        public void Configure(EntityTypeBuilder<BundleCourse> builder)
        {
            builder.HasKey(e => e.Id);
        }
        
    }
}