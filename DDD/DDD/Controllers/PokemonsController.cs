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

        [HttpGet("details")]
        public async Task<ActionResult> Details()
        {
            try
            {
                var result = await this.pokemonsService.GetPokemonsAsync();
                if (result == null || !result.Any())
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
