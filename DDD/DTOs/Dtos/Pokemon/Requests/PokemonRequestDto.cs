using DTOs.Bases;

namespace DTOs.Dtos.Pokemon.Requests
{
    public record PokemonRequestDto : BaseRequest
    {
        public string name { get; }

        public PokemonRequestDto(string name = "")
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Nome é obrigatório");
        }
    }
}
