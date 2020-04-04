using Bridge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class QuizProgressConfiguration: IEntityTypeConfiguration<QuizProgress>
    {
        public void Configure(EntityTypeBuilder<QuizProgress> builder)
        {
            builder.HasKey(e => e.Id);
        }
    }
}