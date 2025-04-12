using DTOs.Bases;

namespace DTOs.Dtos.Pokemon
{
    public record ListPokemonsResponseDto : BaseResponse
    {
        public int Count { get; set; }
        public string? Next { get; set; }
        public string? Previous { get; set; }
        public List<ItemPokemonsResultDto> Results { get; set; } = new();
    }

    public record ItemPokemonsResultDto : BaseResponse
    {
        public string Name { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
    }
}
