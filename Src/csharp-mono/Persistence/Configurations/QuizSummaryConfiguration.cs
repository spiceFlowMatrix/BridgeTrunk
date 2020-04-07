using Bridge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class QuizSummaryConfiguration: IEntityTypeConfiguration<QuizSummary>
    {
        public void Configure(EntityTypeBuilder<QuizSummary> builder)
        {
            builder.HasKey(e => e.Id);
        }
        
    }
}