using EF.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EF.WebAPI.Data
{
    public class AppDbContext: DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> opt): base(opt)
        {

        }

        public DbSet<Filme> Filmes { get; set; }

        public DbSet<User> Users { get; set; }
    }
}
