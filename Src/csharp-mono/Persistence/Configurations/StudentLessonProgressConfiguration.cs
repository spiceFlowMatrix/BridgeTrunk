using Bridge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class StudentLessonProgressConfiguration: IEntityTypeConfiguration<StudentLessonProgress>
    {
        public void Configure(EntityTypeBuilder<StudentLessonProgress> builder)
        {
            builder.HasKey(e => e.Id);
        }
        
    }
}