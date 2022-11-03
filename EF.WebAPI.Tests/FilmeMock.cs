using EF.WebAPI.Data;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.WebAPI.Tests
{
    public class FilmeMock
    {
        public static async Task CreateFilmes(WebApiAplication application, bool criar)
        {
            using (var scope = application.Services.CreateScope())
            {
                var provider = scope.ServiceProvider;
                using (var filmeDbContext = provider.GetRequiredService<AppDbContext>())
                {
                    await filmeDbContext.Database.EnsureCreatedAsync();

                    if(criar)
                    {
                        await filmeDbContext.Filmes.AddAsync(
                            new Models.Filme { Diretor = "John", Duracao = 120, Nome = "Filme1" });

                        await filmeDbContext.Filmes.AddAsync(
                            new Models.Filme { Diretor = "Sara", Duracao = 90, Nome = "NovoFilme2" });

                        await filmeDbContext.SaveChangesAsync();
                    }
                }
            }
        }
    }
}
