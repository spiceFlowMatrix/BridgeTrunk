using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Bridge.Domain.Entities;

namespace Persistence.Configurations
{
    public class AssignmentSubmissionConfiguration: IEntityTypeConfiguration<AssignmentSubmission>
    {
        public void Configure(EntityTypeBuilder<AssignmentSubmission> builder)
        {
            builder.HasKey(e => e.Id);
        }
        
    }
}