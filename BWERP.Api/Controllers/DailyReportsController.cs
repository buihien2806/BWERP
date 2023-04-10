using BWERP.Api.Entities;
using BWERP.Api.Repositories.Interfaces;
using BWERP.Api.Repositories.Services;
using BWERP.Models.DepartmentDailyReport;
using BWERP.Models.Enums;
using BWERP.Models.Task;
using Microsoft.AspNetCore.Mvc;

namespace BWERP.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DailyReportsController : ControllerBase
	{
		private readonly IDailyReportRepository _dailyReport;
		public DailyReportsController(IDailyReportRepository dailyReport)
		{
			_dailyReport = dailyReport;
		}

		[HttpGet]
		public async Task<IActionResult> GetAllReport()
		{
			var users = await _dailyReport.GetListDailyReport();

			var userDtos = users.Select(x => new DailyReportView()
			{
				Id = x.Id,
				TodayTask = x.TodayTask,
				TomorrowTask = x.TomorrowTask,
				CreatedBy = x.AppUser.UserName,
				CreatedDate = x.CreatedDate,
				UpdatedDate = x.UpdatedDate,
				DepartmentName = x.Department.Name
			}).OrderByDescending(x => x.CreatedDate);
			return Ok(userDtos);
		}
		[HttpPost]
		public async Task<IActionResult> Create([FromBody] DailyReportCreateRequest request)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			var result = await _dailyReport.Create(new DailyReport()
			{
				TodayTask = request.TodayTask,
				TomorrowTask = request.TomorrowTask,
				
				CreatedDate = DateTime.Now,
				UserId = request.UserId,
				DepartmentId = request.DepartmentId
			});
			return Ok();
		}
		[HttpGet]
		[Route("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var result = await _dailyReport.GetDailyReportById(id);
			if (result == null)
			{
				return NotFound($"{id} is not found");
			}
			return Ok(new DailyReportView()
			{
				TodayTask = result.TodayTask,
				TomorrowTask = result.TomorrowTask,
				DepartmentId = result.DepartmentId,
				UserId = result.UserId,
				Id = result.Id,
				CreatedDate = result.CreatedDate,
				UpdatedDate = result.UpdatedDate
			});
		}
		[HttpPut]
		[Route("{id}")]
		public async Task<IActionResult> Update(int id, [FromBody] DailyReportUpdateRequest request)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			var taskFromDb = await _dailyReport.GetDailyReportById(id);

			if (taskFromDb == null)
			{
				return NotFound($"{id} is not found");
			}

			taskFromDb.TodayTask = request.TodayTask;
			taskFromDb.TomorrowTask = request.TomorrowTask;
			taskFromDb.UpdatedDate = DateTime.Now;	
			taskFromDb.UserId = request.UserId;
			taskFromDb.DepartmentId = request.DepartmentId;
			var taskResult = await _dailyReport.Update(taskFromDb);

			return Ok();
		}
		[HttpDelete]
		[Route("{id}")]
		public async Task<IActionResult> Delete([FromRoute] int id)
		{
			var task = await _dailyReport.GetDailyReportById(id);
			if (task == null) return NotFound($"{id} is not found");

			await _dailyReport.Delete(task);
			return Ok();
		}
	}
}
