using Microsoft.EntityFrameworkCore;

namespace Data.Context;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
            
    }
}
