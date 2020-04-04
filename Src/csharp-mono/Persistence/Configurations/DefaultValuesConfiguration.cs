using Bridge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class DefaultValuesConfiguration: IEntityTypeConfiguration<DefaultValues>
    {
        public void Configure(EntityTypeBuilder<DefaultValues> builder)
        {
            builder.HasKey(e => e.Id);
        }
        
    }
}