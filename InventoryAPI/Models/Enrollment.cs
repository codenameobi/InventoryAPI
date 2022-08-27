namespace InventoryAPI.Models
{
    public class Enrollment : BaseEntity
    {
        public int EquipmentId { get; set; }
        public int EventId { get; set; }

        public virtual Event Event { get; set; }
        public virtual Equipment Equipment { get; set; }
    }
}

