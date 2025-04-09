namespace Domain.Entities
{
    public class PokemonColor : BaseDomain
    {
        public string Name { get; set; }
        public string Url { get; set; }

        public virtual ICollection<Pokemons> Pokemons { get; set; }
    }
}
