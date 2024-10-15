using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TriviaMusical.Models;

namespace TriviaMusical.Data
{
    public class TriviaDbContext : DbContext
    {
        public TriviaDbContext(DbContextOptions<TriviaDbContext> options) : base(options)
        {
        }

        public DbSet<Musica> Musicas { get; set; } // Define a tabela "Musicas"
    }
}
