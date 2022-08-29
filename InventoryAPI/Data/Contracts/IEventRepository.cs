using System;
using InventoryAPI.Models;

namespace InventoryAPI.Data.Contracts
{
    public interface IEventRepository : IGenericRepository<Event> 
	{
		Task<Event> GetEventDetails(int eventId);

	}
}

