using Blazored.Toast.Services;
using BWERP.Models.DepartmentDailyReport;
using BWERP.Models.Email;
using BWERP.Models.SeedWork;
using BWERP.Repositories.Interfaces;
using BWERP.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace BWERP.Pages.DepartmentDailyReport
{
	public partial class DailyReportDetail
	{
		[Inject] private IDailyReportApiClient dailyReportApiClient { get; set; }
		[Inject] private IEmailApiClient emailApiClient { get; set; }
		[Inject] IToastService toastService { set; get; }
			 
		private List<DailyReportView> dailyReportViews;
		private DailyReportListSearch rptsearch = new DailyReportListSearch();
		private EmailDto emailDto = new EmailDto();

		public MetaData MetaData { get; set; } = new MetaData();
		[CascadingParameter]
		private Error? _error { get; set; }

		protected override async Task OnInitializedAsync()
		{
			rptsearch.CreatedDate = DateTime.Now.Date;
			await GetListDailyReport();
		}
		private async Task GetListDailyReport()
		{
			try
			{				
				dailyReportViews = await dailyReportApiClient.GetListDailyRptSearch(rptsearch);
			}
			catch (Exception ex)
			{
				_error.ProcessError(ex);
			}
		}
		//SEARCH REPORT
		private async Task SearchForm(EditContext editContext)
		{
			dailyReportViews.Clear();
			await GetListDailyReport();
			if (dailyReportViews.Count <= 0)
			{
				toastService.ShowInfo($"No data found.");
			}
		}
		//SEND AN EMAIL
		private async Task SendEmail()
		{
			if (dailyReportViews.Count > 0)
			{
				DateTime? dateRpt = rptsearch.CreatedDate;

				List<string> stringList = dailyReportViews.Select(s => s.HtmlBody).ToList();

				emailDto.ToAdress = "bthien@buwon.com";
				emailDto.Subject = dateRpt.HasValue ? $"{dateRpt.Value.ToString("MM/dd/yyyy")} - Department Daily Report" : "<not available>";
				emailDto.Body = "Dear all," + " We would like to share you the report on " + dateRpt.Value.ToString("MM/dd/yyyy") + ". Please take a look at this as below. " + string.Join("", stringList);
				var result = await emailApiClient.SendEmailAsync(emailDto);
				if (result)
				{
					toastService.ShowSuccess($"Email has been sent successfully.");
				}
				else
				{
					toastService.ShowError($"An error occurred in progress. Please contact to administrator.");

				}
			}
			else
			{
				toastService.ShowInfo($"No data found.");
			}
		}
	}
}
