using BWERP.Api.Entities;
using BWERP.Api.Repositories.Interfaces;
using BWERP.Models.Comment;
using BWERP.Models.DepartmentDailyReport;
using Microsoft.AspNetCore.Mvc;

namespace BWERP.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CommentsController : ControllerBase
	{
		private readonly ICommentRepository _comment;
		public CommentsController(ICommentRepository comment)
		{
			_comment = comment;
		}

		[HttpGet]
		public async Task<IActionResult> GetAllComment()
		{
			var users = await _comment.GetListComment();

			var userDtos = users.Select(x => new CommentViewRequest()
			{
				Id = x.Id,
				Content = x.Content,
				Function = x.Function,
				CreatedBy = x.CreatedBy,
				CreatedDate = x.CreatedDate,
				UpdatedDate = x.UpdatedDate,
				UpdatedBy = x.UpdatedBy

			}).OrderByDescending(x => x.CreatedDate);
			return Ok(userDtos);
		}

		[HttpGet]
		[Route("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var result = await _comment.GetCommentById(id);
			if (result == null)
			{
				return NotFound($"{id} is not found");
			}
			return Ok(new CommentViewRequest()
			{
				Content = result.Content,
				Function = result.Function,
				CreatedBy = result.CreatedBy,
				Id = result.Id,
				CreatedDate = result.CreatedDate,
				UpdatedDate = result.UpdatedDate,
				UpdatedBy = result.UpdatedBy
			});
		}
		[HttpGet]
		[Route("function/{id}")]		
		public async Task<IActionResult> GetByFunctionId(int id)
		{
			var result = await _comment.GetCommentByFuncId(id);
			if (result == null)
			{
				return NotFound($"{id} is not found");
			}
			return Ok(new CommentViewRequest()
			{
				Content = result.Content,
				Function = result.Function,
				CreatedBy = result.CreatedBy,
				Id = result.Id,
				CreatedDate = result.CreatedDate,
				UpdatedDate = result.UpdatedDate,
				UpdatedBy = result.UpdatedBy
			});
		}

		[HttpPost]
		public async Task<IActionResult> Create([FromBody] CommentCreateRequest request)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			var result = await _comment.Create(new Comment()
			{
				Content = request.Content.Replace("<table>", @"<table class=""table table-bordered"">"),
				Function = request.Functions,

				CreatedDate = DateTime.Now,
				CreatedBy = request.CreatedBy,
				UpdatedDate = DateTime.Now,
				UpdatedBy= request.UpdatedBy
			});
			return Ok();
		}

		[HttpPut]
		[Route("{id}")]
		public async Task<IActionResult> Update(int id, [FromBody] CommentEditRequest request)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			var taskFromDb = await _comment.GetCommentById(id);

			if (taskFromDb == null)
			{
				return NotFound($"{id} is not found");
			}

			taskFromDb.Content = request.Content.Replace("<table>", @"<table class=""table table-bordered"">");
			taskFromDb.UpdatedBy = request.UpdatedBy;
			taskFromDb.UpdatedDate = DateTime.Now;
			
			var taskResult = await _comment.Update(taskFromDb);

			return Ok();
		}
	}
}
