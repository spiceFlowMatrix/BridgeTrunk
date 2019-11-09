using System.Threading;
using System.Threading.Tasks;
using Bridge.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bridge.Application.Common.Interfaces
{
    public interface IBridgeDbContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Project> Projects { get; set; }
        DbSet<Organization> Organizations { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}