using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InventoryAPI.Data;
using InventoryAPI.Models;
using AutoMapper;
using InventoryAPI.DTOs.Equipment;
using InventoryAPI.DTOs.Event;

namespace InventoryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipmentController : ControllerBase
    {
        private readonly InventoryDbContext _context;
        private readonly IMapper _mapper;

        public EquipmentController(InventoryDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Equipment
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EquipmentDto>>> GetEquipments()
        {
          if (_context.Equipments == null)
          {
              return NotFound();
          }
            var equipments = await _context.Equipments.ToListAsync();
            var data = _mapper.Map<List<EquipmentDto>>(equipments);
            return data;
        }

        // GET: api/Equipment/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EquipmentDto>> GetEquipment(int id)
        {
          if (_context.Equipments == null)
          {
              return NotFound();
          }
            var equipment = await _context.Equipments.FindAsync(id);

            if (equipment == null)
            {
                return NotFound();
            }
            var data = _mapper.Map<EquipmentDto>(equipment);

            return data;
        }

        // PUT: api/Equipment/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEquipment(int id, EquipmentDto equipmentDto)
        {
            var foundModel = await _context.Equipments.FindAsync(id);

            if (foundModel is null)
            {
                return BadRequest();
            }
            _mapper.Map(equipmentDto, foundModel);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EquipmentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Equipment
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Equipment>> PostEquipment(CreateEquipmentDto equipmentDto)
        {
            var equipment = _mapper.Map<Equipment>(equipmentDto);
            _context.Equipments.Add(equipment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEquipment", new { id = equipment.Id }, equipment);
        }

        // DELETE: api/Equipment/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEquipment(int id)
        {
            if (_context.Equipments == null)
            {
                return NotFound();
            }
            var equipment = await _context.Equipments.FindAsync(id);
            if (equipment == null)
            {
                return NotFound();
            }

            _context.Equipments.Remove(equipment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EquipmentExists(int id)
        {
            return (_context.Equipments?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
