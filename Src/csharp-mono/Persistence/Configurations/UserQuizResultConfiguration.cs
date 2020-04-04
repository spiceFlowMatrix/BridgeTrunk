using Bridge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class UserQuizResultConfiguration: IEntityTypeConfiguration<UserQuizResult>
    {
        public void Configure(EntityTypeBuilder<UserQuizResult> builder)
        {
            builder.HasKey(e => e.Id);
        }
        
    }
}