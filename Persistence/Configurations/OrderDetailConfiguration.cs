using Bridge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bridge.Persistence.Configurations
{
    public class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.HasKey(e => new { e.OrderId, e.ProductId });

            builder.HasOne(e => e.Product)
                .WithMany(e => e.OrderDetails)
                .HasForeignKey(e => e.ProductId);

            builder.HasOne(e => e.Order)
                .WithMany(e => e.OrderDetails)
                .HasForeignKey(e => e.OrderId);
        }
    }
}
