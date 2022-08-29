namespace InventoryAPI.Models
{
    public class Equipment : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }

        public List<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    }
}

