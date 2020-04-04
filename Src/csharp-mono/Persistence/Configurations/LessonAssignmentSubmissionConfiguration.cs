using Bridge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class LessonAssignmentSubmissionConfiguration: IEntityTypeConfiguration<LessonAssignmentSubmission>
    {
        public void Configure(EntityTypeBuilder<LessonAssignmentSubmission> builder)
        {
            builder.HasKey(e => e.Id);
        }
        
    }
}