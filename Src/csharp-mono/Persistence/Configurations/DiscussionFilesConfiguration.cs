using Bridge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class DiscussionFilesConfiguration: IEntityTypeConfiguration<DiscussionFiles>
    {
        public void Configure(EntityTypeBuilder<DiscussionFiles> builder)
        {
            builder.HasKey(e => e.Id);
        }
        
    }
}