using Bridge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class LessonAssignmentSubmissionFileConfiguration: IEntityTypeConfiguration<LessonAssignmentSubmissionFile>
    {
        public void Configure(EntityTypeBuilder<LessonAssignmentSubmissionFile> builder)
        {
            builder.HasKey(e => e.Id);
        }
        
    }
}