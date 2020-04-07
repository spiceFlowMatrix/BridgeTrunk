using Bridge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class ChapterQuizChapterQuizConfiguration: IEntityTypeConfiguration<ChapterQuiz>
    {
        public void Configure(EntityTypeBuilder<ChapterQuiz> builder)
        {
            builder.HasKey(e => e.Id);
        }
        
    }
}