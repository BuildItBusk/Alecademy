using Api.Data.Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    public class BrewryController : ControllerBase
    {
        private ILogger<BrewryController> _logger;
        private SqlContext _db;

        public BrewryController(ILogger<BrewryController> logger, SqlContext db)
        {
            _logger = logger;
            _db = db;
        }

        [HttpGet]
        public IActionResult GetRecent(int num = 5)
        {
            var breweries = _db.Breweries.OrderByDescending(b => b.Id).Take(num);
            return Ok(breweries);
        }
    }
}
