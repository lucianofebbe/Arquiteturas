using DTOs.Dtos.Pokemon.Requests;
using Interfaces.Facade.PokemonFacade;
using Microsoft.AspNetCore.Mvc;
using System.Threading;

namespace DDD.Controllers
{
    [ApiController]
    [Route("PokemonsApi")]
    public class PokemonsController : Controller
    {
        private IPokemonFacade pokemonFacade;

        public PokemonsController(IPokemonFacade pokemonFacade)
        {
            this.pokemonFacade = pokemonFacade;
        }

        [HttpGet]
        [ApiExplorerSettings(IgnoreApi = true)]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet("updateDataBase")]
        public async Task<ActionResult> UpdateDataBase(CancellationToken cancellationToken)
        {
            try
            {
                var result = await this.pokemonFacade.UpdateDataBasePokemonAsync(cancellationToken);
                if (result == null)
                    return NotFound("Nenhum pokemon encontrado");

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }

        [HttpGet("listPokemons")]
        public async Task<ActionResult> ListPokemons(ListPokemonsRequestDto request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await this.pokemonFacade.GetAllPokemonsAsync(request, cancellationToken);
                if (result == null)
                    return NotFound("Nenhum pokemon encontrado");

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }

        [HttpGet("getPokemon")]
        public async Task<ActionResult> GetPokemon(PokemonRequestDto request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await this.pokemonFacade.GetPokemonAsync(request, cancellationToken);
                if (result == null)
                    return NotFound("Nenhum pokemon encontrado");

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }
    }
}
