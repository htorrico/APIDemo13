using APIDemo13.Models;
using Microsoft.EntityFrameworkCore;

namespace APIDemo13.Controllers
{
    public class SchoolContext : DbContext
    {
        public SchoolContext(DbContextOptions<SchoolContext> options): base(options)
        {

        }
        public DbSet<Student> Students { get; set; }
    }
}
