using Blazored.Toast.Services;
using BWERP.Models.Comment;
using BWERP.Models.DepartmentDailyReport;
using BWERP.Models.SeedWork;
using BWERP.Repositories.Interfaces;
using BWERP.Shared;
using Microsoft.AspNetCore.Components;

namespace BWERP.Pages.Comment
{
	public partial class CommentList
	{
		[Inject] private ICommentApiClient commentApiClient { get; set; }
		[Inject] IToastService toastService { set; get; }

		private List<CommentViewRequest> commentViews;
		public MetaData MetaData { get; set; } = new MetaData();
		[CascadingParameter]
		private Error? _error { get; set; }

		protected override async Task OnInitializedAsync()
		{
			await GetListComment();
		}
		private async Task GetListComment()
		{
			try
			{
				commentViews = await commentApiClient.GetListComment();
			}
			catch (Exception ex)
			{
				_error.ProcessError(ex);
			}
		}
	}
}
