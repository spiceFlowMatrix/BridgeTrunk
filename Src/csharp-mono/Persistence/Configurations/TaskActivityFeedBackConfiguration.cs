using Bridge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class TaskActivityFeedBackConfiguration: IEntityTypeConfiguration<TaskActivityFeedBack>
    {
        public void Configure(EntityTypeBuilder<TaskActivityFeedBack> builder)
        {
            builder.HasKey(e => e.Id);
        }
        
    }
}