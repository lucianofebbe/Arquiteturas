using DTOs.Dtos.Pokemon.Requests;
using FluentValidation;

namespace DTOs.Validators
{
    public class PokemonRequestDtoValidator : AbstractValidator<PokemonRequestDto>
    {
        public PokemonRequestDtoValidator()
        {
            //RuleFor(x => x.Name)
            //    .NotEmpty().WithMessage("Digite o nome do Pokemon");
        }
    }
}
