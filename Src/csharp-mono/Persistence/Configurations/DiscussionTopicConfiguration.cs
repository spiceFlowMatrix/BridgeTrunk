using Bridge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class DiscussionTopicConfiguration: IEntityTypeConfiguration<DiscussionTopic>
    {
        public void Configure(EntityTypeBuilder<DiscussionTopic> builder)
        {
            builder.HasKey(e => e.Id);
        }
        
    }
}