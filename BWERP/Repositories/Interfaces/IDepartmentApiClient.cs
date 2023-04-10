using BWERP.Models.Department;
using BWERP.Models.Menu;

namespace BWERP.Repositories.Interfaces
{
	public interface IDepartmentApiClient
	{
		Task<List<DepartmentViewDto>> GetDepartmentList();
	}
}
