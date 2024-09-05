using backendForStudentRegisterApp.Models;
using Microsoft.AspNetCore.Mvc.Razor.TagHelpers;
using Microsoft.EntityFrameworkCore;

namespace backendForStudentRegisterApp.Database
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }
        public DbSet<StudentEntity> StudentRegister { get; set; }
    
    }
}
