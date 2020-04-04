using Bridge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class FileTypesConfiguration: IEntityTypeConfiguration<FileTypes>
    {
        public void Configure(EntityTypeBuilder<FileTypes> builder)
        {
            builder.HasKey(e => e.Id);
        }
        
    }
}