namespace InventoryAPI.Models
{
    public class Event : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public List<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    }
}

