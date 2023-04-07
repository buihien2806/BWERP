using BWERP.Api.Entities;

namespace BWERP.Api.Repositories.Interfaces
{
	public interface IUserRepository
	{
		Task<List<AppUser>> GetListUser();
		Task<AppUser> GetUserById(Guid id);
		Task<AppUser> Create(AppUser user);
		Task<AppUser> Update(AppUser user);
		Task<AppUser> Delete(AppUser user);
	}
}
