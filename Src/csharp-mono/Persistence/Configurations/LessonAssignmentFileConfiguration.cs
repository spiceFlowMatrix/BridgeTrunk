using Bridge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class LessonAssignmentFileConfiguration: IEntityTypeConfiguration<LessonAssignmentFile>
    {
        public void Configure(EntityTypeBuilder<LessonAssignmentFile> builder)
        {
            builder.HasKey(e => e.Id);
        }
        
    }
}