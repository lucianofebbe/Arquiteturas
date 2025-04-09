namespace Domain.Entities
{
    public class Pokemons : BaseDomain
    {
        public string Name { get; set; }
        public string Url { get; set; }

        public virtual ICollection<PokemonColor> PokemonColor { get; set; }
    }
}
