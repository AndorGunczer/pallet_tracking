using Microsoft.EntityFrameworkCore;
using UserService.Models;

namespace UserService;

public class UsersDbContext : DbContext, IUsersDbContext
{
    public UsersDbContext(DbContextOptions<UsersDbContext> options): base(options)
    {
        
    }
    public DbSet<User> Users { get; set; }
    
}