using Domain.Entities;
using FluentValidation;

namespace Domain.Validators
{
    public class PokemonValidator : AbstractValidator<Pokemon>
    {
        public PokemonValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Digite o nome do Pokémon");
        }
    }
}
