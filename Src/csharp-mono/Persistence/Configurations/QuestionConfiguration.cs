using Bridge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class QuestionConfiguration: IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.QuestionText).IsRequired();
            builder.Property(e => e.QuestionText).HasMaxLength(255);
            builder.Property(e => e.Explanation).HasMaxLength(255);
        }
    }
}