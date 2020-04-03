using Bridge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class AppTimeTrackConfiguration: IEntityTypeConfiguration<AppTimeTrack>
    {
        public void Configure(EntityTypeBuilder<AppTimeTrack> builder)
        {
            builder.HasKey(e => e.Id);
        }
    }
}