using BWERP.Api.Repositories.Interfaces;
using BWERP.Models.Enums;
using BWERP.Models.Task;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace BWERP.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TasksController : ControllerBase
	{
		private readonly ITaskRepository _taskRepository;
		public TasksController(ITaskRepository taskRepository)
		{
			_taskRepository = taskRepository;
		}
		[HttpGet]
		public async Task<IActionResult>GetAllTask()
		{
			var task = await _taskRepository.GetAllTask();	
			return Ok(task);
		}
		[HttpPost]
		public async Task<IActionResult> Create([FromBody] TaskCreateRequest request)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			var result = await _taskRepository.Create(new Entities.Task()
			{
				Name = request.Name,
                Priority = request.Priority.HasValue ? request.Priority.Value : Priority.Low,
                Status = Status.Open,
                CreatedDate = DateTime.Now,
			});
			return Ok();
		}
		[HttpGet]
		[Route("{id}")]
		public async Task<IActionResult> GetById(Guid id)
		{
			var result = await _taskRepository.GetTaskById(id);
			if (result == null)
			{
				return NotFound($"{id} is not found");
			}
			return Ok(new TaskViewRequest()
			{
				Name = result.Name,
				Status = result.Status,
				Id = result.Id,
				AssigneeId = result.AssigneeId,
				Priority = result.Priority,
				CreatedDate = result.CreatedDate
			});
		}
		[HttpPut]
		[Route("{id}")]
		public async Task<IActionResult> Update(Guid id, [FromBody] TaskUpdateRequest request)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			var taskFromDb = await _taskRepository.GetTaskById(id);

			if (taskFromDb == null)
			{
				return NotFound($"{id} is not found");
			}

			taskFromDb.Name = request.Name;
			taskFromDb.Priority = request.Priority;
			taskFromDb.Status = request.Status;
			var taskResult = await _taskRepository.Update(taskFromDb);

			return Ok();
		}
		[HttpDelete]
		[Route("{id}")]
		public async Task<IActionResult> Delete([FromRoute] Guid id)
		{
			var task = await _taskRepository.GetTaskById(id);
			if (task == null) return NotFound($"{id} is not found");

			await _taskRepository.Delete(task);
			return Ok();
		}
	}
}
