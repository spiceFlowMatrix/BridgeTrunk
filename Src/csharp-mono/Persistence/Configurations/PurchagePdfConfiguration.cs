using Bridge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class PurchagePdfConfiguration: IEntityTypeConfiguration<PurchagePdf>
    {
        public void Configure(EntityTypeBuilder<PurchagePdf> builder)
        {
            builder.HasKey(e => e.Id);
        }
        
    }
}