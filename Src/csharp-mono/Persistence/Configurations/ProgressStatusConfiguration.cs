using Bridge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class ProgressStatusConfiguration: IEntityTypeConfiguration<ProgressStatus>
    {
        public void Configure(EntityTypeBuilder<ProgressStatus> builder)
        {
            builder.HasKey(e => e.Id);
        }
        
    }
}