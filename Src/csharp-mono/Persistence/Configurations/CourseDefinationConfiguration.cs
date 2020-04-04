using Bridge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class CourseDefinationConfiguration: IEntityTypeConfiguration<CourseDefination>
    {
        public void Configure(EntityTypeBuilder<CourseDefination> builder)
        {
            builder.HasKey(e => e.Id);
        }
        
    }
}