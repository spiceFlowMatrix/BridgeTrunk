using Bridge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class UserSessionsConfiguration: IEntityTypeConfiguration<UserSessions>
    {
        public void Configure(EntityTypeBuilder<UserSessions> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e=> e.DeviceType).HasMaxLength(10);
            builder.Property(e=> e.Version).HasMaxLength(20);
        }
        
    }
}