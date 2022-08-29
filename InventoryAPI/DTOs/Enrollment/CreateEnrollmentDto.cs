using InventoryAPI.DTOs.Equipment;
using InventoryAPI.DTOs.Event;

namespace InventoryAPI.DTOs.Enrollment
{
    public class CreateEnrollmentDto
    {
        public int EquipmentId { get; set; }
        public int EventId { get; set; }
    }
}

