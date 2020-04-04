using Bridge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class SalesTaxConfiguration: IEntityTypeConfiguration<SalesTax>
    {
        public void Configure(EntityTypeBuilder<SalesTax> builder)
        {
            builder.HasKey(e => e.Id);
        }
        
    }
}