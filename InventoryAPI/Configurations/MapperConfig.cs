using System;
using AutoMapper;
using InventoryAPI.DTOs.Enrollment;
using InventoryAPI.DTOs.Equipment;
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
            CreateMap<Event, EventDetailsDto>()
				.ForMember(q => q.Equipments, x => x.MapFrom(model => model.Enrollments.Select(stu => stu.Equipment)));

            CreateMap<Equipment, CreateEquipmentDto>().ReverseMap();
			CreateMap<Equipment, EquipmentDto>().ReverseMap();

			CreateMap<Enrollment, CreateEnrollmentDto>().ReverseMap();
			CreateMap<Enrollment, EnrollmentDto>().ReverseMap();
        }
	}
}

