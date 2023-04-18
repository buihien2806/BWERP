using BWERP.Api.EF;
using BWERP.Api.Entities;
using BWERP.Api.Repositories.Interfaces;
using BWERP.Models.DepartmentDailyReport;
using BWERP.Models.Task;
using Microsoft.EntityFrameworkCore;

namespace BWERP.Api.Repositories.Services
{
	public class DailyReportRepository : IDailyReportRepository
	{
		private readonly MainContext _mainContext;
		public DailyReportRepository(MainContext mainContext)
		{
			_mainContext = mainContext;
		}

		public async Task<DailyReport> Create(DailyReport rep)
		{
			await _mainContext.DailyReports.AddAsync(rep);
			await _mainContext.SaveChangesAsync();
			return rep; 
		}

		public async Task<DailyReport> Delete(DailyReport rep)
		{
			_mainContext.DailyReports.Remove(rep);
			await _mainContext.SaveChangesAsync();
			return rep;
		}

		public async Task<DailyReport> GetDailyReportById(int id)
		{
			return await _mainContext.DailyReports.FindAsync(id);
		}

		public async Task<List<DailyReport>> GetListDailyReport()
		{
			var query = _mainContext.DailyReports
				.Include(x => x.AppUser)
				.Include(x => x.Department).AsQueryable();

			return await query.OrderByDescending(x => x.CreatedDate).ToListAsync();
		}

		public async Task<List<DailyReport>> GetListDailyRptSearch(DailyReportListSearch dailyrptsearch)
		{
			DateTime searchDate = DateTime.Today;
			var query = _mainContext.DailyReports
				.Include(x => x.AppUser)
				.Include(x => x.Department).AsQueryable();

			query = query.Where(t => t.CreatedDate.Date == dailyrptsearch.CreatedDate);

			return await query.OrderByDescending(x => x.CreatedDate).ToListAsync();
		}

		public async Task<DailyReport> Update(DailyReport rep)
		{
			_mainContext.DailyReports.Update(rep);
			await _mainContext.SaveChangesAsync();
			return rep;
		}
	}
}
