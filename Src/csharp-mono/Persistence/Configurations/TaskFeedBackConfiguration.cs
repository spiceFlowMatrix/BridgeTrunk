using Bridge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class TaskFeedBackConfiguration: IEntityTypeConfiguration<TaskFeedBack>
    {
        public void Configure(EntityTypeBuilder<TaskFeedBack> builder)
        {
            builder.HasKey(e => e.Id);
        }
        
    }
}