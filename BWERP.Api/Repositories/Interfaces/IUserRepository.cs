using BWERP.Api.Entities;

namespace BWERP.Api.Repositories.Interfaces
{
	public interface IUserRepository
	{
		Task<List<User>> GetListUser();
	}
}
