using Bridge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class QuestionFileConfiguration: IEntityTypeConfiguration<QuestionFile>
    {
        public void Configure(EntityTypeBuilder<QuestionFile> builder)
        {
            builder.HasKey(e => e.Id);
        }
        
    }
}