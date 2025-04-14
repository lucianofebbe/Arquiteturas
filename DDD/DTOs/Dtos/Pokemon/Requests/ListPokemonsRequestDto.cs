using DTOs.Bases;

namespace DTOs.Dtos.Pokemon.Requests
{
    public record ListPokemonsRequestDto : BaseRequest
    {
        public int offset { get; }
        public int limit { get; }

        public ListPokemonsRequestDto(int offset = 0, int limit = 0)
        {
            if (limit <= 0)
                limit = int.MaxValue;
        }
    }
}
