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
using InventoryAPI.DTOs.Enrollment;
using InventoryAPI.DTOs.Equipment;

namespace InventoryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentController : ControllerBase
    {
        private readonly InventoryDbContext _context;
        private readonly IMapper _mapper;

        public EnrollmentController(InventoryDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Enrollment
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EnrollmentDto>>> GetEnrollments()
        {
          if (_context.Enrollments == null)
          {
              return NotFound();
          }
            var enrollments = await _context.Enrollments.ToListAsync();
            var data = _mapper.Map<List<EnrollmentDto>>(enrollments);
            return data;
        }

        // GET: api/Enrollment/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EnrollmentDto>> GetEnrollment(int id)
        {
          if (_context.Enrollments == null)
          {
              return NotFound();
          }
            var enrollment = await _context.Enrollments.FindAsync(id);

            if (enrollment == null)
            {
                return NotFound();
            }
            var data = _mapper.Map<EnrollmentDto>(enrollment);

            return data;
        }

        // PUT: api/Enrollment/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEnrollment(int id, EnrollmentDto enrollmentDto)
        {
            var foundModel = await _context.Enrollments.FindAsync(id);

            if (foundModel is null)
            {
                return BadRequest();
            }
            _mapper.Map(enrollmentDto, foundModel);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EnrollmentExists(id))
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

        // POST: api/Enrollment
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Enrollment>> PostEnrollment(EnrollmentDto enrollmentDto)
        {
          if (_context.Enrollments == null)
          {
              return Problem("Entity set 'InventoryDbContext.Enrollments'  is null.");
          }

            var enrollment = _mapper.Map<Enrollment>(enrollmentDto);
            _context.Enrollments.Add(enrollment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEnrollment", new { id = enrollment.Id }, enrollment);
        }

        // DELETE: api/Enrollment/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEnrollment(int id)
        {
            if (_context.Enrollments == null)
            {
                return NotFound();
            }
            var enrollment = await _context.Enrollments.FindAsync(id);
            if (enrollment == null)
            {
                return NotFound();
            }

            _context.Enrollments.Remove(enrollment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EnrollmentExists(int id)
        {
            return (_context.Enrollments?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
