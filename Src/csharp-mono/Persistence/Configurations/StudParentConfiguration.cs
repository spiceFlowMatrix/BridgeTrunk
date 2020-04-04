using Bridge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class StudParentConfiguration: IEntityTypeConfiguration<StudParent>
    {
        public void Configure(EntityTypeBuilder<StudParent> builder)
        {
            builder.HasKey(e => e.Id);
        }
        
    }
}