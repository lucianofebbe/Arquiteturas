using DTOs.Bases;

namespace DTOs.Dtos.Pokemon.Requests
{
    public record PokemonRequestDto : BaseRequest
    {
        public string Name { get; set; }
    }
}
