using Api.Data.Contexts;
using Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeerController : ControllerBase
    {
        private readonly ILogger<BeerController> _logger;
        private readonly SqlContext _db;

        public BeerController(ILogger<BeerController> logger, SqlContext db)
        {
            _logger = logger;
            _db = db;
        }
        
        [HttpGet]
        public IActionResult Get()
        {
            var rng = new Random();
            _logger.LogInformation("User requested a random beer.");
            _logger.LogInformation($"Database contains {_db.Beers.Count()} beers.");
            return Ok(Beers[rng.Next(Beers.Count)]);
        }

        private readonly List<Beer> Beers = new List<Beer>
        {
            new Beer { Name = "Tuborg Classic", AlcoholVol = 5.6m, Origin = new Country { Name = "Denmark" }},
            new Beer { Name = "Grimbergen Blonde", AlcoholVol = 6.7m, Origin = new Country { Name = "France" }}
        };
    }
}