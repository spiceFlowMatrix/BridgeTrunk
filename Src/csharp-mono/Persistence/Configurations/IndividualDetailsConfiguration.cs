using Bridge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class IndividualDetailsConfiguration: IEntityTypeConfiguration<IndividualDetails>
    {
        public void Configure(EntityTypeBuilder<IndividualDetails> builder)
        {
            builder.HasKey(e => e.Id);
        }
        
    }
}