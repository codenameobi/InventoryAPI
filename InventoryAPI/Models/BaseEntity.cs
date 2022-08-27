using System;
using Microsoft.Extensions.Logging;

namespace InventoryAPI.Models
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; } = String.Empty;
        public DateTime ModifiedDate { get; set; }
        public string ModifiedBy { get; set; } = String.Empty;
    }
}

