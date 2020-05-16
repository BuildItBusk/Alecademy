using Api.Data.Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
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
            _logger.LogInformation($"Database contains {_db.Beers.Count()} beers.");
        }
        
        [HttpGet]
        public IActionResult Get()
        {
            var rng = new Random();
            _logger.LogInformation("User requested a random beer.");
            int idx = rng.Next(_db.Beers.Count());
            return Ok(_db.Beers.OrderBy(b => Guid.NewGuid()).FirstOrDefault());
        }
    }
}