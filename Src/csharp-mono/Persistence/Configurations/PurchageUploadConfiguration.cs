using Bridge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class PurchageUploadConfiguration: IEntityTypeConfiguration<PurchageUpload>
    {
        public void Configure(EntityTypeBuilder<PurchageUpload> builder)
        {
            builder.HasKey(e => e.Id);
        }
        
    }
}