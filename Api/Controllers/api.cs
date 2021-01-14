using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TempWeb.Data;
using TempWeb.Models;

namespace _.Controllers
{
    
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    
    
    public class Api : ControllerBase
    {
        private readonly DataContext _context;

        public Api(DataContext context)
        {
            _context = context;
        }


        [HttpGet("pets")]
        public async Task<ActionResult> GetPets()
        {
            
            /*
            var  pets =  _context.Pets.ToList();
            var  users = _context.Users.ToList();*/


            const int a = 1;
            
            var users = await _context.Users.Include(u => u.Pets).FirstOrDefaultAsync(x  => x.Id == 1);
            

            return Ok(users);
        }
        
        
        [HttpGet("pets/{id}")]
        public IActionResult GetPet(int id)
        {
            var pet = _context.Pets.FirstOrDefault(x => x.Id == id);
            return Ok(pet);
        }

        
        [HttpGet("help")] 
        public IActionResult Index()
        {
            return Ok("hello world");
        }
    }
}