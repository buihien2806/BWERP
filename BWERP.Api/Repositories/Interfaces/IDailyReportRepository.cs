using BWERP.Api.Entities;

namespace BWERP.Api.Repositories.Interfaces
{
	public interface IDailyReportRepository
	{
		Task<List<DailyReport>> GetListDailyReport();
		Task<DailyReport> GetDailyReportById(int id);
		Task<DailyReport> Create(DailyReport user);
		Task<DailyReport> Update(DailyReport user);
		Task<DailyReport> Delete(DailyReport user);
	}
}
