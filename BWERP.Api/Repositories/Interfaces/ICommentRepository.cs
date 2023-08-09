using BWERP.Api.Entities;
using BWERP.Models.DepartmentDailyReport;

namespace BWERP.Api.Repositories.Interfaces
{
	public interface ICommentRepository
	{
		Task<List<Comment>> GetListComment();
		Task<Comment> GetCommentById(int id);
		Task<Comment> GetCommentByFuncId(int id);
		Task<Comment> Create(Comment cmt);
		Task<Comment> Update(Comment cmt);
		Task<Comment> Delete(Comment cmt);
	}
}
