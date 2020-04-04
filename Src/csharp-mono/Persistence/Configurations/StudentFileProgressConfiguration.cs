using Bridge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class StudentFileProgressConfiguration: IEntityTypeConfiguration<StudentFileProgress>
    {
        public void Configure(EntityTypeBuilder<StudentFileProgress> builder)
        {
            builder.HasKey(e => e.Id);
        }
        
    }
}