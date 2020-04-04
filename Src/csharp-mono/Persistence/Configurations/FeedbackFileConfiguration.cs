using Bridge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class FeedbackFileConfiguration: IEntityTypeConfiguration<FeedbackFile>
    {
        public void Configure(EntityTypeBuilder<FeedbackFile> builder)
        {
            builder.HasKey(e => e.Id);
        }
        
    }
}