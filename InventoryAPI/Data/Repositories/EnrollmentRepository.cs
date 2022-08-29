using InventoryAPI.Data.Contracts;
using InventoryAPI.Data.Repositories;
using InventoryAPI.Models;

namespace InventoryAPI.Data.Repositories
{
    public class EnrollmentRepository : GenericRepository<Enrollment>, IEnrollmentRepository
    {
        public EnrollmentRepository(InventoryDbContext db) : base(db)
        {
        }
    }
}

