using BWERP.Models.Comment;
using BWERP.Models.DepartmentDailyReport;
using BWERP.Repositories.Interfaces;

namespace BWERP.Repositories.Services
{
	public class CommentApiClient : ICommentApiClient
	{
		public HttpClient _httpClient;
		public CommentApiClient(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}
		public async Task<bool> CreateComment(CommentCreateRequest request)
		{
			var result = await _httpClient.PostAsJsonAsync("/api/comments", request);
			return result.IsSuccessStatusCode;
		}

		public async Task<bool> DeleteComment(int id)
		{
			var result = await _httpClient.DeleteAsync($"/api/comments/{id}");
			return result.IsSuccessStatusCode;
		}

		public async Task<CommentViewRequest> GetCommentByFuncId(int id)
		{
			var result = await _httpClient.GetFromJsonAsync<CommentViewRequest>($"/api/comments/function/{id}");
			return result;
		}

		public async Task<CommentViewRequest> GetCommentById(int id)
		{
			var result = await _httpClient.GetFromJsonAsync<CommentViewRequest>($"/api/comments/{id}");
			return result;
		}

		public async Task<List<CommentViewRequest>> GetListComment()
		{
			var result = await _httpClient.GetFromJsonAsync<List<CommentViewRequest>>($"/api/comments");
			return result;
		}
 
		public async Task<bool> UpdateComment(int id, CommentEditRequest request)
		{
			var result = await _httpClient.PutAsJsonAsync($"/api/comments/{id}", request);
			return result.IsSuccessStatusCode;
		}
	}
}
