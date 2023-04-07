using BWERP.Api.Entities;
using BWERP.Api.Repositories.Interfaces;
using BWERP.Api.Repositories.Services;
using BWERP.Models.Enums;
using BWERP.Models.SeedWork;
using BWERP.Models.Task;
using BWERP.Models.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BWERP.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UsersController : ControllerBase
	{
		private readonly IUserRepository _userRepository;
		public UsersController(IUserRepository userRepository) 
		{ 
			_userRepository = userRepository;
		}
		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var users = await _userRepository.GetListUser();
			var assignees = users.Select(x => new AssigneeDto()
			{

				Id = x.Id,
				Fullname = x.FirstName + " " + x.LastName
			});

			return Ok(assignees);
		}
		[HttpGet("all")]
		public async Task<IActionResult> GetAllUser()
		{
			var users = await _userRepository.GetListUser();

			var userDtos = users.Select(x => new UserViewRequest()
			{
				Id = x.Id,
				FirstName =x.FirstName,
				LastName =x.LastName,
				Email = x.Email,
				CreatedDate = x.CreatedDate,
				isActive = x.isActive,
				Username = x.UserName
			}).OrderByDescending(x => x.CreatedDate);
			return Ok(userDtos);
		}
		[HttpPost]
		public async Task<IActionResult> Create([FromBody] UserCreateRequest request)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			var hasher = new PasswordHasher<AppUser>();
			var result = await _userRepository.Create(new AppUser()
			{
				UserName = request.UserName,
				NormalizedUserName = request.UserName.ToUpper(),
				Email = request.Email,
				NormalizedEmail = request.Email.ToUpper(),
				EmailConfirmed = true,
				PasswordHash = hasher.HashPassword(null, "123456"),
				SecurityStamp = Guid.NewGuid().ToString(),
				FirstName = request.FirstName,
				LastName = request.LastName,
				isActive = true,
				CreatedDate = DateTime.Now,
				LastLogin = DateTime.Now
			});
			return Ok();
		}
		[HttpGet]
		[Route("{id}")]
		public async Task<IActionResult> GetById(Guid id)
		{
			var result = await _userRepository.GetUserById(id);
			if (result == null)
			{
				return NotFound($"{id} is not found");
			}
			return Ok(new UserViewRequest()
			{
				FirstName = result.FirstName,
				LastName = result.LastName,
				Username = result.UserName,
				Email = result.Email,
				isActive = result.isActive,
				CreatedDate = result.CreatedDate
			});
		}
		[HttpPut]
		[Route("{id}")]
		public async Task<IActionResult> Update(Guid id, [FromBody] UserUpdateRequest request)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			var taskFromDb = await _userRepository.GetUserById(id);

			if (taskFromDb == null)
			{
				return NotFound($"{id} is not found");
			}

			taskFromDb.FirstName = request.FirstName;
			taskFromDb.LastName = request.LastName;
			taskFromDb.isActive = request.isActive;			
			var taskResult = await _userRepository.Update(taskFromDb);

			return Ok();
		}
		[HttpDelete]
		[Route("{id}")]
		public async Task<IActionResult> Delete([FromRoute] Guid id)
		{
			var task = await _userRepository.GetUserById(id);
			if (task == null) return NotFound($"{id} is not found");

			await _userRepository.Delete(task);
			return Ok();
		}
	}
}
