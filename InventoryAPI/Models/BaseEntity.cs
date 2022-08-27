using System;
using Microsoft.Extensions.Logging;

namespace InventoryAPI.Models
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }

    public class Equipment : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }

    public class Event : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }


    public class Enrollment : BaseEntity
    {
        public int EquipmentId { get; set; }
        public int EventId { get; set; }

        public virtual Event Event { get; set; }
        public virtual Equipment Equipment { get; set; }
    }
}

