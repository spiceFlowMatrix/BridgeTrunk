using Bridge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class FeebackTimeConfiguration: IEntityTypeConfiguration<FeebackTime>
    {
        public void Configure(EntityTypeBuilder<FeebackTime> builder)
        {
            builder.HasKey(e => e.Id);
        }
        
    }
}