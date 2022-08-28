using System;
using InventoryAPI.DTOs.Equipment;
using InventoryAPI.DTOs.Event;

namespace InventoryAPI.DTOs.Enrollment
{
    public class EnrollmentDto
    {
        public int EquipmentId { get; set; }
        public int EventId { get; set; }

        public virtual EventDto Event { get; set; }
        public virtual EquipmentDto Equipment { get; set; }
    }
}

