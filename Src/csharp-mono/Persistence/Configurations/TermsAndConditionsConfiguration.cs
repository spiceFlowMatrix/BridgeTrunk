using Bridge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class TermsAndConditionsConfiguration: IEntityTypeConfiguration<TermsAndConditions>
    {
        public void Configure(EntityTypeBuilder<TermsAndConditions> builder)
        {
            builder.HasKey(e => e.Id);
        }
        
    }
}