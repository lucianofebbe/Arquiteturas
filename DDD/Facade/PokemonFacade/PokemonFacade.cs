using DTOs.Dtos.Pokemon;
using DTOs.Dtos.Pokemon.Responses;
using Interfaces.Facade.PokemonFacade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade.PokemonFacade
{
    public class PokemonFacade : IPokemonFacade
    {
        public Task<ListPokemonsResponseDto> AtualizarBaseDadosPokemonAsync()
        {
            throw new NotImplementedException();
        }

        public Task<PokemonResponseDto> BuscarPokemonAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<ListPokemonsResponseDto> ListarPokemonsAsync(int offset, int limit)
        {
            throw new NotImplementedException();
        }
    }
}
