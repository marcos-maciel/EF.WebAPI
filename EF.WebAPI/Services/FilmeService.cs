using EF.WebAPI.Data;
using EF.WebAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EF.WebAPI.Services
{
    public class FilmeService : IFilmeService
    {
        private readonly AppDbContext _context;

        public FilmeService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Filme>> GetAllFilmes()
        {
            return await _context.Filmes.ToListAsync();
        }

        public async Task<Filme> GetFilmeById(int id)
        {
            return await _context.Filmes.FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task AddFilme(Filme newFilme)
        {
            _context.Filmes.Add(newFilme);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateFilme(Filme filme)
        {
            _context.Filmes.Update(filme);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteFilme(Filme filme)
        {
            _context.Filmes.Remove(filme);
            await _context.SaveChangesAsync();
        }
    }
}
