using Bridge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class StudentChapterProgressConfiguration: IEntityTypeConfiguration<StudentChapterProgress>
    {
        public void Configure(EntityTypeBuilder<StudentChapterProgress> builder)
        {
            builder.HasKey(e => e.Id);
        }
        
    }
}