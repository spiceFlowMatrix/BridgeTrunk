using Bridge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class QuestionAnswerConfiguration: IEntityTypeConfiguration<QuestionAnswer>
    {
        public void Configure(EntityTypeBuilder<QuestionAnswer> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Answer).IsRequired();
            builder.Property(e => e.Answer).HasMaxLength(255);
            builder.Property(e => e.ExtraText).HasMaxLength(255);
        }
        
    }
}