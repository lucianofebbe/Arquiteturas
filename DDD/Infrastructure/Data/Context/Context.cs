using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Context
{
    public class Context : DbContext
    {
        public DbSet<Pokemon> Pokemon { get; set; }
        public DbSet<PokemonColor> PokemonColor { get; set; }
        public DbSet<Pokemons> Pokemons { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    @"Data Source=(LocalDB)\MSSQLLocalDB;Database=C:/Users/lucia/Documents/Empresa/Arquiteturas/DDD/Infrastructure/Data/Db/Database1.mdf;Integrated Security=True");
            }
        }
    }
}
