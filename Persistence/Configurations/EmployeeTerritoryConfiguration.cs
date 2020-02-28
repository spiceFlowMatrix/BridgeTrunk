using Bridge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bridge.Persistence.Configurations
{
    public class EmployeeTerritoryConfiguration : IEntityTypeConfiguration<EmployeeTerritory>
    {
        public void Configure(EntityTypeBuilder<EmployeeTerritory> builder)
        {
            builder.HasKey(e => new { e.EmployeeId, e.TerritoryId });

            builder.HasOne(e => e.Employee)
                .WithMany(e => e.EmployeeTerritories)
                .HasForeignKey(e => e.EmployeeId);

            builder.HasOne(e => e.Territory)
                .WithMany(e => e.EmployeeTerritories)
                .HasForeignKey(e => e.TerritoryId);
        }
    }
}
