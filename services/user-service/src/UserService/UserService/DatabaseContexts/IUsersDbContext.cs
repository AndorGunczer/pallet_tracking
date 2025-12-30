using Microsoft.EntityFrameworkCore;
using UserService.Models;

namespace UserService;

public interface IUsersDbContext
{    
    DbSet<User> Users { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}