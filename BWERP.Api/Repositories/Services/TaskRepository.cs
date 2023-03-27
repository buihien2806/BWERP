using BWERP.Api.EF;
using BWERP.Api.Repositories.Interfaces;
using BWERP.Models.Enums;
using BWERP.Models.Task;
using Microsoft.EntityFrameworkCore;
using Task = BWERP.Api.Entities.Task;

namespace BWERP.Api.Repositories.Services
{
	public class TaskRepository : ITaskRepository
	{
		private readonly MainContext _mainContext;
		public TaskRepository(MainContext mainContext)
		{
			_mainContext = mainContext;
		}

		public async Task<bool> Create(Task task)
		{
			await _mainContext.Tasks.AddAsync(task);
			return await _mainContext.SaveChangesAsync() > 0;
		}

		public async Task<bool> Delete(Task task)
		{
			_mainContext.Tasks.Remove(task);
			return await _mainContext.SaveChangesAsync() > 0;
		}

		public async Task<List<TaskViewRequest>> GetAllTask()
		{
			var query = from t in _mainContext.Tasks
						select t;
			return await query.Select(x=> new TaskViewRequest()
			{
				Id= x.Id,
				Name= x.Name,
				CreatedDate= x.CreatedDate,
				Priority= x.Priority,
				Status= x.Status
			}).OrderByDescending(x=> x.CreatedDate).ToListAsync();
		}

		public async Task<Task> GetTaskById(Guid id)
		{
			return await _mainContext.Tasks.FindAsync(id);
		}

		public async Task<bool> Update(Task task)
		{
			_mainContext.Tasks.Update(task);
			return await _mainContext.SaveChangesAsync() > 0;			
		}
	}
}
