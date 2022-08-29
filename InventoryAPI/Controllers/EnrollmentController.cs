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
using InventoryAPI.Data.Contracts;

namespace InventoryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentController : ControllerBase
    {
        private readonly InventoryDbContext _context;
        private readonly IEnrollmentRepository _repo;
        private readonly IMapper _mapper;

        public EnrollmentController(IEnrollmentRepository repo, IMapper mapper)
        {
            this._repo = repo;
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
            var enrollments = await _repo.GetAllAsync();
            var data = _mapper.Map<List<EnrollmentDto>>(enrollments);
            return data;
        }

        // GET: api/Enrollment/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EnrollmentDto>> GetEnrollment(int id)
        {
            return await _repo.GetAsync(id)
                is Enrollment model
                ? Ok(_mapper.Map<EnrollmentDto>(model)) : NotFound();
        }

        // PUT: api/Enrollment/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEnrollment(int id, EnrollmentDto enrollmentDto)
        {
            var foundModel = await _repo.GetAsync(id);
            if (foundModel is null)
            {
                return BadRequest();
            }
            _mapper.Map(enrollmentDto, foundModel);

            try
            {
                await _repo.UpdateAsync(foundModel);
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
        public async Task<ActionResult<Enrollment>> PostEnrollment(CreateEnrollmentDto enrollmentDto)
        {
            var enrollment = _mapper.Map<Enrollment>(enrollmentDto);
            await _repo.AddAsync(enrollment);

            return CreatedAtAction("GetEnrollment", new { id = enrollment.Id }, enrollment);
        }

        // DELETE: api/Enrollment/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEnrollment(int id)
        {
            return await _repo.DeleteAsync(id) ?  NoContent(): NotFound();
        }

        private bool EnrollmentExists(int id)
        {
            return (_context.Enrollments?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
