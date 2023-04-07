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
		public async Task<AppUser> Create(AppUser user)
		{
			await _mainContext.Users.AddAsync(user);
			await _mainContext.SaveChangesAsync();
			return user;
		}

		public async Task<AppUser> Delete(AppUser user)
		{
			_mainContext.Users.Remove(user);
			await _mainContext.SaveChangesAsync();
			return user;
		}
		public async Task<AppUser> GetUserById(Guid id)
		{
			return await _mainContext.Users.FindAsync(id);
		}

		public async Task<AppUser> Update(AppUser user)
		{
			_mainContext.Users.Update(user);
			await _mainContext.SaveChangesAsync();
			return user;
		}
	}
}
