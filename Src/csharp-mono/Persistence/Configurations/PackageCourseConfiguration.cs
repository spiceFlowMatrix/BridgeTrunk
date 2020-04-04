using Bridge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class PackageCourseConfiguration: IEntityTypeConfiguration<PackageCourse>
    {
        public void Configure(EntityTypeBuilder<PackageCourse> builder)
        {
            builder.HasKey(e => e.Id);
        }
        
    }
}