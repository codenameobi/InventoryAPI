using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryAPI.Data;
using InventoryAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InventoryAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventController : Controller
    {

        public InventoryDbContext _context;
        public EventController(InventoryDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public  async Task<ActionResult<Event>> Index()
        {
            var events = await _context.Events.ToListAsync();
            return Ok(events);
        }

        [Route("{id}")]
        [HttpGet]
        public async Task<ActionResult> GetEvent(int id)
        {
            var events = await _context.Events.FindAsync(id);
            if (events == null)
                return NotFound();
            return Ok(events);
        }

        [HttpPost]
        public async Task<ActionResult> CreateEvent(Event newEvent)
        {
            await _context.AddAsync(newEvent);
            await _context.SaveChangesAsync();

            return Created($"/Event/{newEvent.Id}", newEvent);
        }
    }
}

