using Bridge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class CourseRevisionConfiguration : IEntityTypeConfiguration<CourseRevision>
    {
        public void Configure(EntityTypeBuilder<CourseRevision> builder)
        {
            builder.HasKey(e => e.Id);
            builder.HasOne(e => e.Course)
                    .WithMany(c => c.Revisions)
                    .HasForeignKey(x => x.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CourseRevision_Course");
        }
    }
}