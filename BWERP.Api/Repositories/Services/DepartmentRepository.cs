using BWERP.Api.EF;
using BWERP.Api.Entities;
using BWERP.Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BWERP.Api.Repositories.Services
{
	public class DepartmentRepository : IDepartmentRepository
	{
		private readonly MainContext _mainContext;
		public DepartmentRepository(MainContext mainContext)
		{
			_mainContext = mainContext;
		}
		public async Task<List<Department>> GetDepartmentList()
		{
			return await _mainContext.Departments.ToListAsync();
		}
	}
}
