using Bridge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class FeedBackActivityConfiguration: IEntityTypeConfiguration<FeedBackActivity>
    {
        public void Configure(EntityTypeBuilder<FeedBackActivity> builder)
        {
            builder.HasKey(e => e.Id);
        }
        
    }
}