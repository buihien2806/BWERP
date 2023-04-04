using BWERP.Api.EF;
using BWERP.Api.Entities;
using BWERP.Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BWERP.Api.Repositories.Services
{
	public class UserRepository : IUserRepository
	{
		private readonly MainContext _mainContext;
		public UserRepository(MainContext mainContext)
		{
			_mainContext = mainContext;
		}
		public async Task<List<AppUser>> GetListUser()
		{
			return await _mainContext.Users.ToListAsync();
		}
	}
}
