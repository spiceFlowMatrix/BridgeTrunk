using Bridge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class TaskActivityCategoryFeedBackConfiguration: IEntityTypeConfiguration<TaskActivityCategoryFeedBack>
    {
        public void Configure(EntityTypeBuilder<TaskActivityCategoryFeedBack> builder)
        {
            builder.HasKey(e => e.Id);
        }
        
    }
}