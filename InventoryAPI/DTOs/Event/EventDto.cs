﻿using System;
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
}

