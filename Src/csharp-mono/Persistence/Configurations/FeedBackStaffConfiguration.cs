using Bridge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class FeedBackStaffConfiguration: IEntityTypeConfiguration<FeedBackStaff>
    {
        public void Configure(EntityTypeBuilder<FeedBackStaff> builder)
        {
            builder.HasKey(e => e.Id);
        }
        
    }
}