using DTOs.Bases;

namespace DTOs.Dtos.Pokemon.Requests
{
    public record PokemonRequestDto : BaseRequest
    {
        public string name { get; set; }
    }
}
