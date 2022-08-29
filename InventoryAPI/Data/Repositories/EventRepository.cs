using InventoryAPI.Data.Contracts;
using InventoryAPI.Data.Repositories;
using InventoryAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace InventoryAPI.Data.Repositories
{
    public class EventRepository : GenericRepository<Event>, IEventRepository
    {
        public EventRepository(InventoryDbContext db) : base(db)
        {
        }

        public async Task<Event> GetEventDetails(int eventId)
        {
            var model = await _db.Events
                .Include(q => q.Enrollments).ThenInclude(q => q.Equipment)
                .FirstOrDefaultAsync(q => q.Id == eventId);

            return model;
        }
    }
}

