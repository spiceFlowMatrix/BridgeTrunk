using Bridge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class FeedBackCategoryConfiguration: IEntityTypeConfiguration<FeedBackCategory>
    {
        public void Configure(EntityTypeBuilder<FeedBackCategory> builder)
        {
            builder.HasKey(e => e.Id);
        }
        
    }
}