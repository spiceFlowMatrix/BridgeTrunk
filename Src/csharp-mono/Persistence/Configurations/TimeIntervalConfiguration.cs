using Bridge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class TimeIntervalConfiguration: IEntityTypeConfiguration<TimeInterval>
    {
        public void Configure(EntityTypeBuilder<TimeInterval> builder)
        {
            builder.HasKey(e => e.Id);
        }
        
    }
}