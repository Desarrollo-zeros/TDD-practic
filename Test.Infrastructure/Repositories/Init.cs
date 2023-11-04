using Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Infrastructure.Repositories
{
    public class Init
    {
        public AppDbContext AppDbContext { set; get; }

        public Init() {
            // Configura una base de datos en memoria
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            // Crea un contexto de base de datos utilizando la base de datos en memoria
            AppDbContext = new AppDbContext(options);
        }
    }
}
