using BWERP.Api.Repositories.Interfaces;
using BWERP.Models.Task;
using Microsoft.AspNetCore.Http;
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
	}
}
