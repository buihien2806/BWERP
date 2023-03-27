using BWERP.Models.Task;
using BWERP.Repositories.Interfaces;

namespace BWERP.Repositories.Services
{
	public class TaskApiClient : ITaskApiClient
	{
		public HttpClient _httpClient;
		public TaskApiClient(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}
		public async Task<List<TaskViewRequest>> GetListTask()
		{
			var result = await _httpClient.GetFromJsonAsync<List<TaskViewRequest>>("/api/tasks");
			return result;
		}
	}
}
