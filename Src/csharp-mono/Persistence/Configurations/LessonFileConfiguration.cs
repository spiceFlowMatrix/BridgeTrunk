using Bridge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class LessonFileConfiguration: IEntityTypeConfiguration<LessonFile>
    {
        public void Configure(EntityTypeBuilder<LessonFile> builder)
        {
            builder.HasKey(e => e.Id);
        }
        
    }
}