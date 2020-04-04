using Bridge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class ERPAccountsConfiguration: IEntityTypeConfiguration<ERPAccounts>
    {
        public void Configure(EntityTypeBuilder<ERPAccounts> builder)
        {
            builder.HasKey(e => e.Id);
        }
        
    }
}