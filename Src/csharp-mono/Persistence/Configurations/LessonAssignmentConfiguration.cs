using Bridge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class LessonAssignmentConfiguration: IEntityTypeConfiguration<LessonAssignment>
    {
        public void Configure(EntityTypeBuilder<LessonAssignment> builder)
        {
            builder.HasKey(e => e.Id);
        }
        
    }
}