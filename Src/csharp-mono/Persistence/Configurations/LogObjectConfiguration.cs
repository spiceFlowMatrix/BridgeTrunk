using Bridge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class LogObjectConfiguration: IEntityTypeConfiguration<LogObject>
    {
        public void Configure(EntityTypeBuilder<LogObject> builder)
        {
            builder.HasKey(e => e.Id);
        }
        
    }
}