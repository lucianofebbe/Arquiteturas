using Interfaces.Application.Services.PokemonsService;
using Microsoft.AspNetCore.Mvc;

namespace DDD.Controllers
{
    [ApiController]
    [Route("PokemonsApi")]
    public class PokemonsController : Controller
    {
        private IPokemonsService pokemonsService;

        public PokemonsController(IPokemonsService pokemonsService)
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
        public async Task<ActionResult> ListPokemons(int offset = 10, int limit = 20)
        {
            try
            {
                var result = await this.pokemonsService.GetPokemonsAsync(offset, limit);
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
        public async Task<ActionResult> GetPokemon(string name)
        {
            try
            {
                var result = await this.pokemonsService.GetPokemonAsync(name);
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
