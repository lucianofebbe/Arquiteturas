using DTOs.Bases;

namespace DTOs.Dtos
{
    public record PokemonResultDto : BaseResponse
    {
        public string Name { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
    }
}
