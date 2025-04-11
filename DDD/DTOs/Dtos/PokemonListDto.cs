using DTOs.Bases;

namespace DTOs.Dtos
{
    public record PokemonListDto : BaseResponse
    {
        public int Count { get; set; }
        public string? Next { get; set; }
        public string? Previous { get; set; }
        public List<PokemonResultDto> Results { get; set; } = new();
    }
}
