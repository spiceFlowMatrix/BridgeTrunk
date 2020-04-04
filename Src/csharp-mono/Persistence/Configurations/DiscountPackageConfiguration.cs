using Bridge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class DiscountPackageConfiguration: IEntityTypeConfiguration<DiscountPackage>
    {
        public void Configure(EntityTypeBuilder<DiscountPackage> builder)
        {
            builder.HasKey(e => e.Id);
        }
        
    }
}