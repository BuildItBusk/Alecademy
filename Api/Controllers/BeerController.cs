using Api.Data.Contexts;
using Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

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
            _logger.LogInformation($"Database contains {_db.Beers.Count()} beers.");
        }
        
        [HttpGet]
        public IActionResult Get(string name)
        {
            _logger.LogInformation($"Searching for beer name '{name}'.");
            var beer = _db.Beers.Where(b => b.Name.Contains(name) || b.Brewery.Name.Contains(name));

            if (beer.Any()) return Ok(beer);
            return NotFound($"No beer or brewery named '{name}' exists in the database.");
        }

        [HttpPost]
        public async Task<ActionResult<Beer>> AddBeer(Beer beer)
        {
            if (beer.Brewery != null)
                return BadRequest("Use 'BreweryId' to refer to an existing origin, when adding beers.");

            if (_db.Beers.Where(b => b.Name == beer.Name).Any())
                return BadRequest($"A beer with the name '{beer.Name}' already exists.");

            _db.Beers.Add(beer);
            await _db.SaveChangesAsync();

            return CreatedAtAction(nameof(AddBeer), new { id = beer.Id }, beer);
        }
    }
}