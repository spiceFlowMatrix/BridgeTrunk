using Bridge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class DiscussionCommentFilesConfiguration: IEntityTypeConfiguration<DiscussionCommentFiles>
    {
        public void Configure(EntityTypeBuilder<DiscussionCommentFiles> builder)
        {
            builder.HasKey(e => e.Id);
        }
        
    }
}