using Bridge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class AnswerFileConfiguration : IEntityTypeConfiguration<AnswerFile>
    {
        public void Configure(EntityTypeBuilder<AnswerFile> builder)
        {
            builder.HasKey(e => e.Id);
        }
    }
}