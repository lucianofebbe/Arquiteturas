using DTOs.Dtos.Pokemon.Requests;
using FluentValidation;

namespace DTOs.Validators
{
    public class ListPokemonsRequestDtoValidator : AbstractValidator<ListPokemonsRequestDto>
    {
        public ListPokemonsRequestDtoValidator()
        {
        }
    }
}
