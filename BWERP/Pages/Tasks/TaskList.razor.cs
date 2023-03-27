using BWERP.Models.Task;
using BWERP.Repositories.Interfaces;
using Microsoft.AspNetCore.Components;

namespace BWERP.Pages.Tasks
{
	public partial class TaskList
	{
		[Inject] private ITaskApiClient taskApiClient { get; set; }

		private List<TaskViewRequest> taskViewRequests;

		protected override async Task OnInitializedAsync()
		{
			taskViewRequests = await taskApiClient.GetListTask();
			//Get Assignees
			//assigneeLists = await userRepository.GetAssignees();
		}
	}
}
