using System;
using InventoryAPI.DTOs.Equipment;

namespace InventoryAPI.DTOs.Event
{
	public class EventDto
	{
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }

    public class CreateEventDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }

    public class EventDetailsDto : CreateEventDto
    {
        public List<EquipmentDto> Equipments { get; set; } = new List<EquipmentDto>();
    }
}

