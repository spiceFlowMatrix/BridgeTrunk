using Bridge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class DiscussionCommentLikesConfiguration: IEntityTypeConfiguration<DiscussionCommentLikes>
    {
        public void Configure(EntityTypeBuilder<DiscussionCommentLikes> builder)
        {
            builder.HasKey(e => e.Id);
        }
        
    }
}