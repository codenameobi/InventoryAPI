using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InventoryAPI.Data;
using InventoryAPI.Models;
using InventoryAPI.DTOs.Event;
using AutoMapper;
using InventoryAPI.Data.Contracts;
using InventoryAPI.DTOs.Enrollment;

namespace InventoryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventRepository _repo;
        private readonly IMapper _mapper;

        public EventController(IEventRepository repo, IMapper mapper)
        {
            this._repo = repo;
            _mapper = mapper;
        }

        // GET: api/Event
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventDto>>> GetEvents()
        {
            var events = await _repo.GetAllAsync();
            var data = _mapper.Map<List<EventDto>>(events);
            return data;
        }

        // GET: api/Event/5

        [HttpGet("{id}")]
        public async Task<ActionResult<Event>> GetEvent(int id)
        {
            return await _repo.GetAsync(id)
                is Event model
                ? Ok(_mapper.Map<EventDto>(model))
                : NotFound();
        }

        // GET: api/Event/GetEvent/5

        [HttpGet("GetEvent/{id}")]
        public async Task<ActionResult<Event>> GetEventDetails(int id)
        {
            return await _repo.GetEventDetails(id)
                is Event model
                ? Ok(_mapper.Map<EventDetailsDto>(model))
                : NotFound();
        }

        // PUT: api/Event/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEvent(int id, EventDto @event)
        {

            var foundModel = await _repo.GetAsync(id);
            if (foundModel is null)
            {
                return BadRequest();
            }

            var data = _mapper.Map(@event, foundModel);
            await _repo.UpdateAsync(data);
            return NoContent();
        }

        // POST: api/Event
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Event>> PostEvent(CreateEventDto eventDto)
        {
            var newEvent = _mapper.Map<Event>(eventDto);
            _repo.AddAsync(newEvent);

            return CreatedAtAction("GetEvent", new { id = newEvent.Id }, newEvent);
        }

        // DELETE: api/Event/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvent(int id)
        {
            return await _repo.DeleteAsync(id) ? NoContent() : NotFound();
        }

    }
}
