using BWERP.Models.Task;

namespace BWERP.Repositories.Interfaces
{
	public interface IUserApiClient
	{
		Task<List<AssigneeDto>> GetAssignees();
	}
}
