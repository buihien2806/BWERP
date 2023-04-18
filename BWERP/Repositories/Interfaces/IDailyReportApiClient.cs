using BWERP.Models.DepartmentDailyReport;
using BWERP.Models.SeedWork;
using BWERP.Models.Task;

namespace BWERP.Repositories.Interfaces
{
	public interface IDailyReportApiClient
	{
		Task<List<DailyReportView>> GetListDailyReport();
		Task<List<DailyReportView>> GetListDailyRptSearch(DailyReportListSearch dailyrptsearch);
		Task<DailyReportView> GetReportById(int id);
		Task<bool> CreateDailyReport(DailyReportCreateRequest request);
		Task<bool> UpdateDailyReport(int id, DailyReportUpdateRequest request);
		Task<bool> DeleteDailyReport(int id);
	}
}
