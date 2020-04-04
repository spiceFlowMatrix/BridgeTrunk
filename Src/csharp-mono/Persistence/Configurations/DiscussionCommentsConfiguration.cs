using Bridge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class DiscussionCommentsConfiguration: IEntityTypeConfiguration<DiscussionComments>
    {
        public void Configure(EntityTypeBuilder<DiscussionComments> builder)
        {
            builder.HasKey(e => e.Id);
        }
        
    }
}