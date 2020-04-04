using Bridge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class TaskFileFeedBackConfiguration: IEntityTypeConfiguration<TaskFileFeedBack>
    {
        public void Configure(EntityTypeBuilder<TaskFileFeedBack> builder)
        {
            builder.HasKey(e => e.Id);
        }
        
    }
}