using Bridge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class LogObjectTypesConfiguration: IEntityTypeConfiguration<LogObjectTypes>
    {
        public void Configure(EntityTypeBuilder<LogObjectTypes> builder)
        {
            builder.HasKey(e => e.Id);
        }
        
    }
}