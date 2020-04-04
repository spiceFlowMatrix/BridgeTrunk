using Bridge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class SubcriptionsConfiguration: IEntityTypeConfiguration<Subcriptions>
    {
        public void Configure(EntityTypeBuilder<Subcriptions> builder)
        {
            builder.HasKey(e => e.Id);
        }
        
    }
}