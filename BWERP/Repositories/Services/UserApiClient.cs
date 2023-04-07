using BWERP.Models.Menu;
using BWERP.Models.SeedWork;
using BWERP.Models.Task;
using BWERP.Models.User;
using BWERP.Repositories.Interfaces;
using Microsoft.AspNetCore.WebUtilities;

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
		public async Task<List<UserViewRequest>> GetListUser()
		{
			var result = await _httpClient.GetFromJsonAsync<List<UserViewRequest>>($"/api/users/all");
			return result;
		}

		public async Task<UserViewRequest> GetUserById(string id)
		{
			var result = await _httpClient.GetFromJsonAsync<UserViewRequest>($"/api/users/{id}");
			return result;
		}
		public async Task<bool> CreateUser(UserCreateRequest request)
		{
			var result = await _httpClient.PostAsJsonAsync("/api/users", request);
			return result.IsSuccessStatusCode;
		}

		public async Task<bool> DeleteUser(Guid id)
		{
			var result = await _httpClient.DeleteAsync($"/api/users/{id}");
			return result.IsSuccessStatusCode;
		}

		public async Task<bool> UpdateUser(Guid id, UserUpdateRequest request)
		{
			var result = await _httpClient.PutAsJsonAsync($"/api/users/{id}", request);
			return result.IsSuccessStatusCode;
		}

		
	}
}
