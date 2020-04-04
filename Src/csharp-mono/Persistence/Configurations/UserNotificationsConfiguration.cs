using Bridge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class UserNotificationsConfiguration: IEntityTypeConfiguration<UserNotifications>
    {
        public void Configure(EntityTypeBuilder<UserNotifications> builder)
        {
            builder.HasKey(e => e.Id);
        }
    }
}