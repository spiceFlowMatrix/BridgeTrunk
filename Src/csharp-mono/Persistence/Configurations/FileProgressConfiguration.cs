using Bridge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class FileProgressConfiguration: IEntityTypeConfiguration<FileProgress>
    {
        public void Configure(EntityTypeBuilder<FileProgress> builder)
        {
            builder.HasKey(e => e.Id);
        }
        
    }
}