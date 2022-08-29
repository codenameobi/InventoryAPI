using System;
using Microsoft.AspNetCore.Identity;

namespace InventoryAPI.Models
{
	public class User : IdentityUser
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
	}
}

