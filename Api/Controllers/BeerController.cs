using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeerController : ControllerBase
    {
        private readonly ILogger<BeerController> _logger;

        public BeerController(ILogger<BeerController> logger)
        {
            _logger = logger;            
        }
        
        [HttpGet]
        public Beer Get()
        {
            var rng = new Random();
            _logger.LogInformation("User requested a random beer.");
            return Beers[rng.Next(Beers.Count)];
        }

        private readonly List<Beer> Beers = new List<Beer>
        {
            new Beer { Name = "Tuborg Classic", AlcoholVol = 5.6m, Origin = new Country { Name = "Denmark" }},
            new Beer { Name = "Grimbergen Blonde", AlcoholVol = 6.7m, Origin = new Country { Name = "France" }}
        };
    }
}