using Bridge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class SalesAgentConfiguration: IEntityTypeConfiguration<SalesAgent>
    {
        public void Configure(EntityTypeBuilder<SalesAgent> builder)
        {
            builder.HasKey(e => e.Id);
        }
        
    }
}