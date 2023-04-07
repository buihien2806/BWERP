using BWERP.Models.SeedWork;
using BWERP.Models.Task;
using BWERP.Models.User;

namespace BWERP.Repositories.Interfaces
{
	public interface IUserApiClient
	{
		Task<List<AssigneeDto>> GetAssignees();
        Task<List<UserViewRequest>> GetListUser();

        Task<UserViewRequest> GetUserById(string id);
        Task<bool> CreateUser(UserCreateRequest request);
        Task<bool> UpdateUser(Guid id, UserUpdateRequest request);
        Task<bool> DeleteUser(Guid id);
    }
}
