using Bridge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class LessonConfiguration: IEntityTypeConfiguration<Lesson>
    {
        public void Configure(EntityTypeBuilder<Lesson> builder)
        {
            builder.HasKey(e => e.Id);
            builder.HasOne(d => d.Chapter)
                .WithMany(p => p.Lessons)
                .HasForeignKey(x => x.ChapterId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Lesson_Chapter");
        }
        
    }
}