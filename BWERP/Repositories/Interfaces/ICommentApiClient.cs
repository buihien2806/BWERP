using BWERP.Models.Comment;
using BWERP.Models.DepartmentDailyReport;

namespace BWERP.Repositories.Interfaces
{
	public interface ICommentApiClient
	{
		Task<List<CommentViewRequest>> GetListComment();
		Task<CommentViewRequest> GetCommentById(int id);
		Task<CommentViewRequest> GetCommentByFuncId(int id);
		Task<bool> CreateComment(CommentCreateRequest request);
		Task<bool> UpdateComment(int id, CommentEditRequest request);
		Task<bool> DeleteComment(int id);
	}
}
