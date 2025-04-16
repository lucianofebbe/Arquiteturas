using DTOs.Bases;

namespace DTOs.Dtos.Pokemon.Requests
{
    public record ListPokemonsRequestDto : BaseRequest
    {
        public int offset { get; set; }
        public int limit { get; set; }
    }
}
