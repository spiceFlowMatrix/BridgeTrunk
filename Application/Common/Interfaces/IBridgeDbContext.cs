using System.Threading;
using System.Threading.Tasks;
using Bridge.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bridge.Application.Common.Interfaces
{
    public interface IBridgeDbContext
    {
        DbSet<ProductCategory> ProductCategories { get; set; }

        DbSet<Customer> Customers { get; set; }

        DbSet<Employee> Employees { get; set; }

        DbSet<EmployeeTerritory> EmployeeTerritories { get; set; }

        DbSet<OrderDetail> OrderDetails { get; set; }

        DbSet<Order> Orders { get; set; }

        DbSet<Product> Products { get; set; }

        DbSet<Region> Region { get; set; }

        DbSet<Shipper> Shippers { get; set; }

        DbSet<Supplier> Suppliers { get; set; }

        DbSet<Territory> Territories { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}