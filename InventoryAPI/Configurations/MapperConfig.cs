using System;
using AutoMapper;
using InventoryAPI.DTOs.Event;
using InventoryAPI.Models;

namespace InventoryAPI.Configurations
{
	public class MapperConfig : Profile
	{
		public MapperConfig()
		{
			CreateMap<Event, EventDto>().ReverseMap();
            CreateMap<Event, CreateEventDto>().ReverseMap();
        }
	}
}

