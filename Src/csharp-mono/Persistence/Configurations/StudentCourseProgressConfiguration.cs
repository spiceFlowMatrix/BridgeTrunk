using Bridge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class StudentCourseProgressConfiguration: IEntityTypeConfiguration<StudentCourseProgress>
    {
        public void Configure(EntityTypeBuilder<StudentCourseProgress> builder)
        {
            builder.HasKey(e => e.Id);
        }
        
    }
}