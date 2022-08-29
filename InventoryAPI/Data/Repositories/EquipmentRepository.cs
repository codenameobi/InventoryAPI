using InventoryAPI.Data.Contracts;
using InventoryAPI.Data.Repositories;
using InventoryAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace InventoryAPI.Data.Repositories
{
    public class EquipmentRepository : GenericRepository<Equipment>, IEquipmentRepository
    {
        public EquipmentRepository(InventoryDbContext db) : base(db)
        {
        }

        public async Task<Equipment> GetEquipmentList(int equipmentId)
        {
            var model = await _db.Equipments
                .Include(q => q.Enrollments).ThenInclude(q => q.Event)
                .FirstOrDefaultAsync(q => q.Id == equipmentId);

            return model;
        }
    }
}

