using BWERP.Models.Task;
using BWERP.Repositories.Interfaces;

namespace BWERP.Repositories.Services
{
	public class UserApiClient : IUserApiClient
	{
		public HttpClient _httpClient;
		public UserApiClient(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}
		public async Task<List<AssigneeDto>> GetAssignees()
		{
			var result = await _httpClient.GetFromJsonAsync<List<AssigneeDto>>($"/api/users");
			return result;
		}
	}
}
