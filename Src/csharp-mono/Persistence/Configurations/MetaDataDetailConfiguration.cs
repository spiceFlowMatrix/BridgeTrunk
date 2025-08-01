using Bridge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class MetaDataDetailConfiguration: IEntityTypeConfiguration<MetaDataDetail>
    {
        public void Configure(EntityTypeBuilder<MetaDataDetail> builder)
        {
            builder.HasKey(e => e.Id);
        }
        
    }
}