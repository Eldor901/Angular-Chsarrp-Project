using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TempWeb.Data;

namespace _.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private DataContext _context;

        public void ValuesContriller(DataContext context)
        {
            _context = context;
        }


        [HttpGet("pets")]
        public async Task<IActionResult> GetPets()
        {
            var pets = await _context.Pets.ToListAsync();
            return Ok(pets);
        }

        [HttpGet("pets/{id}")]
        public IActionResult GetPet(int id)
        {
            var pet = _context.Pets.FirstOrDefault(x => x.Id == id);
            return Ok(pet);
        }
        
        
        [HttpGet]
        public ActionResult<string> Get()
        {
            return Ok("23");
        }
        
    }
}
