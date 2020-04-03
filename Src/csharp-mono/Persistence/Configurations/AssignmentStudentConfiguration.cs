using Bridge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class AssignmentStudentConfiguration: IEntityTypeConfiguration<AssignmentStudent>
    {
        public void Configure(EntityTypeBuilder<AssignmentStudent> builder)
        {
            builder.HasKey(e => e.Id);
        }
        
    }
}