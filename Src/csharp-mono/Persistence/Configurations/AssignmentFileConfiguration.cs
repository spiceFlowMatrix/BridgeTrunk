using Bridge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class AssignmentFileConfiguration: IEntityTypeConfiguration<AssignmentFile>
    {
        public void Configure(EntityTypeBuilder<AssignmentFile> builder)
        {
            builder.HasKey(e => e.Id);
        }
    }
}