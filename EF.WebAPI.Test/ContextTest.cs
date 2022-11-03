using EF.WebAPI.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EF.WebAPI.Test
{
    public class ContextTest
    {
        private DbContextOptions<AppDbContext> opt;

        public ContextTest()
        {
            opt = new DbContextOptions<AppDbContext>();
        }

        [Fact]
        public void TestarConexaoContext()
        {
            AppDbContext context = new AppDbContext(opt);
            bool conected;

            try
            {
                conected = context.Database.CanConnect();
            } catch
            {
                throw new Exception("Não foi possível conectar com o BD");
            }
        }
    }
}
