using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Context
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        public DbSet<Pokemon> Pokemon { get; set; }
        public DbSet<PokemonColor> PokemonColor { get; set; }
        public DbSet<Pokemons> Pokemons { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    @"Data Source=(LocalDB)\MSSQLLocalDB;
                    AttachDbFilename=C:\Users\lucia\Documents\Empresa\Arquiteturas\DDD\Infrastructure\Data\Db\DataBaseDDD.mdf;
                    Integrated Security=True;
                    Connect Timeout=30");
            }
        }
    }
}
