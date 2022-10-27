using EF.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EF.WebAPI.Data
{
    public class FilmeContext: DbContext
    {
        public FilmeContext(DbContextOptions<FilmeContext> opt): base(opt)
        {

        }

        public DbSet<Filme> Filmes { get; set; }
    }
}
