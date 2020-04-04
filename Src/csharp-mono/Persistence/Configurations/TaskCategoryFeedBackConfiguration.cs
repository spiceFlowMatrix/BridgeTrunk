using Bridge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class TaskCategoryFeedBackConfiguration: IEntityTypeConfiguration<TaskCategoryFeedBack>
    {
        public void Configure(EntityTypeBuilder<TaskCategoryFeedBack> builder)
        {
            builder.HasKey(e => e.Id);
        }
        
    }
}