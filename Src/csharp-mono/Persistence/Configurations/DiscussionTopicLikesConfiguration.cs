using Bridge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class DiscussionTopicLikesConfiguration: IEntityTypeConfiguration<DiscussionTopicLikes>
    {
        public void Configure(EntityTypeBuilder<DiscussionTopicLikes> builder)
        {
            builder.HasKey(e => e.Id);
        }
    }
}