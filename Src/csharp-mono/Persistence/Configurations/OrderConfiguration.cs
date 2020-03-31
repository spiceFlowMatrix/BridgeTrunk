using Bridge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bridge.Persistence.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(e => e.OrderId);

            builder.HasOne(e => e.Customer)
                .WithMany(e => e.Orders)
                .HasForeignKey(e => e.CustomerId);

            builder.HasOne(e => e.Shipper)
                .WithMany(e => e.Orders)
                .HasForeignKey(e => e.ShipVia);

            builder.HasOne(e => e.Employee)
                .WithMany(e => e.Orders)
                .HasForeignKey(e => e.EmployeeId);
        }
    }
}
