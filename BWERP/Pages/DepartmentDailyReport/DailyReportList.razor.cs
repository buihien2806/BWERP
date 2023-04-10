using Blazored.Toast.Services;
using BWERP.Models.DepartmentDailyReport;
using BWERP.Models.SeedWork;
using BWERP.Repositories.Interfaces;
using BWERP.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http.Extensions;
using System;

namespace BWERP.Pages.DepartmentDailyReport
{
	public partial class DailyReportList
	{
		[Inject] private IDailyReportApiClient dailyReportApiClient { get; set; }
		[Inject] IToastService toastService { set; get; }		

		private List<DailyReportView> dailyReportViews;
		public MetaData MetaData { get; set; } = new MetaData();
		[CascadingParameter]
		private Error? _error { get; set; }

		protected override async Task OnInitializedAsync()
		{
			await GetListDailyReport();
		}
		private async Task GetListDailyReport()
		{
			try
			{
				dailyReportViews = await dailyReportApiClient.GetListDailyReport();
			}
			catch (Exception ex)
			{
				_error.ProcessError(ex);
			}
		}
	}
}
