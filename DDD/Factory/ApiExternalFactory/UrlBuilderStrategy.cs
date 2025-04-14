using DTOs.Dtos.Pokemon.Responses;
using Interfaces.Factory.ApiExternalFactory;

namespace Factory.ApiExternalFactory
{
    public class UrlBuilder
    {
    }

    public class PokemonUrlBuilder : IUrlBuilder
    {
        public string BuildUrl(int offset, int limit, string name)
            => $"https://pokeapi.co/api/v2/pokemon/{name}";

        public Type TargetType => typeof(PokemonUrlBuilder);
    }

    public class ListPkemonUrlBuilder : IUrlBuilder
    {
        public string BuildUrl(int offset, int limit, string name)
            => $"https://pokeapi.co/api/v2/pokemon?offset={offset}&limit={limit}";

        public Type TargetType => typeof(ListPokemonsResponseDto);
    }
}
