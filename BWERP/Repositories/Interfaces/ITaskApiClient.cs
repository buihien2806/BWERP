using BWERP.Models.Task;

namespace BWERP.Repositories.Interfaces
{
	public interface ITaskApiClient
	{
		Task<List<TaskViewRequest>> GetListTask(); 
	}
}
