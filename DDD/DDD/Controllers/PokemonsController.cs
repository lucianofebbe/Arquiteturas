using Application.Services.PokemonsService;
using Interfaces.Application.Services.PokemonsService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DDD.Controllers
{
    public class PokemonsController : Controller
    {
        private IPokemonsService pokemonsService;
        PokemonsController(IPokemonsService pokemonsService)
        {
            this.pokemonsService = pokemonsService;
        }
    }
}
