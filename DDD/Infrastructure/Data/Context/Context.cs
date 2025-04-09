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
        }
    }
}
