using System;
using InventoryAPI.DTOs.Authentication;

namespace InventoryAPI.Services
{
    public interface IAuthManager
	{
		Task<AuthResponseDto> Login(LoginDto loginDto);
	}
}

