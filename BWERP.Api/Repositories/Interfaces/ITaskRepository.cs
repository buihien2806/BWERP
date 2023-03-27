using BWERP.Models.Task;
using Microsoft.AspNetCore.Components.Web;
using Task = BWERP.Api.Entities.Task;

namespace BWERP.Api.Repositories.Interfaces
{
	public interface ITaskRepository
	{
		Task<List<TaskViewRequest>> GetAllTask();
		Task<Task> GetTaskById(Guid id);
		Task<bool> Create(Task task);		
		Task<bool> Update(Task task);
		Task<bool> Delete(Task task);
	}
}
