using Bridge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bridge.Persistence.Configurations
{
    public class AddtionalServicesConfiguration: IEntityTypeConfiguration<AddtionalServices>
    {
        public void Configure(EntityTypeBuilder<AddtionalServices> builder)
        {
            builder.HasKey(e => e.Id);
        }
    }
}