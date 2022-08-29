using System;
using InventoryAPI.Models;
using Microsoft.Extensions.Logging;

namespace InventoryAPI.Data.Contracts
{
    public interface IEquipmentRepository : IGenericRepository<Equipment>
	{
		Task<Equipment> GetEquipmentList(int equipmentId);
	}
}

