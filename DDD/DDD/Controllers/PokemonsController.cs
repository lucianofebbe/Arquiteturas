using DTOs.Dtos.Pokemon.Requests;
using Interfaces.Application.Services.PokemonsService;
using Microsoft.AspNetCore.Mvc;

namespace DDD.Controllers
{
    [ApiController]
    [Route("PokemonsApi")]
    public class PokemonsController : Controller
    {
        private IPokemonsApiService pokemonsService;

        public PokemonsController(IPokemonsApiService pokemonsService)
        {
            this.pokemonsService = pokemonsService;
        }

        [HttpGet]
        [ApiExplorerSettings(IgnoreApi = true)]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet("listPokemons")]
        public async Task<ActionResult> ListPokemons(ListPokemonsRequestDto request)
        {
            try
            {
                var result = await this.pokemonsService.GetPokemonsAsync(request);
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
        public async Task<ActionResult> GetPokemon(PokemonRequestDto request)
        {
            try
            {
                var result = await this.pokemonsService.GetPokemonAsync(request);
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
