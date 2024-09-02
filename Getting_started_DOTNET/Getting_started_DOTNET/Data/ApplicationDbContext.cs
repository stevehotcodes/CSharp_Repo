using Getting_started_DOTNET.Model;
using Microsoft.EntityFrameworkCore;

namespace Getting_started_DOTNET.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<StudentEntity> StudentRegister { get; set; }

    }
}
