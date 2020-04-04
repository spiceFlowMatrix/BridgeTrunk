using Bridge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class ChapterProgressConfiguration: IEntityTypeConfiguration<ChapterProgress>
    {
        public void Configure(EntityTypeBuilder<ChapterProgress> builder)
        {
            builder.HasKey(e => e.Id);
        }
        
    }
}