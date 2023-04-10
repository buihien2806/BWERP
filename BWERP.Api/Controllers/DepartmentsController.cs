using BWERP.Api.Repositories.Interfaces;
using BWERP.Api.Repositories.Services;
using BWERP.Models.Department;
using BWERP.Models.Menu;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BWERP.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DepartmentsController : ControllerBase
	{
		private readonly IDepartmentRepository _departmentRepository;
		public DepartmentsController(IDepartmentRepository departmentRepository)
		{
			_departmentRepository = departmentRepository;
		}
		[HttpGet]
		public async Task<IActionResult> GetDepartmentList()
		{
			var result = await _departmentRepository.GetDepartmentList();

			var departmentDto = result.Select(x => new DepartmentViewDto()
			{
				Id = x.Id,
				Name = x.Name
			});
			return Ok(departmentDto);
		}
	}
}
