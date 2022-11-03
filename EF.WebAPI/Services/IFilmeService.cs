using EF.WebAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EF.WebAPI.Services
{
    public interface IFilmeService
    {
        Task<List<Filme>> GetAllFilmes();
        Task<Filme> GetFilmeById(int id);
        Task AddFilme(Filme newFilme);
        Task UpdateFilme(Filme newFilme);
        Task DeleteFilme(Filme newFilme);
    }
}
