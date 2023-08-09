using BWERP.Api.EF;
using BWERP.Api.Entities;
using BWERP.Api.Repositories.Interfaces;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Org.BouncyCastle.Ocsp;
using System.Data;

namespace BWERP.Api.Repositories.Services
{
	public class CommentRepository : ICommentRepository
	{
		private readonly MainContext _mainContext;
		//TEST ADO.NET
		private readonly IConfiguration _configuration;
		private const string Main_Database = "MainDBDatabase";
		//private const string SELECT_BUG = "select * from bugs";
		//
		public CommentRepository(MainContext mainContext, 
								IConfiguration configuration)
		{
			_mainContext = mainContext;
			_configuration = configuration;
		}
		public async Task<Comment> Create(Comment cmt)
		{
			await _mainContext.Comments.AddAsync(cmt);
			await _mainContext.SaveChangesAsync();
			return cmt;
		}

		public async Task<Comment> Delete(Comment cmt)
		{
			_mainContext.Comments.Remove(cmt);
			await _mainContext.SaveChangesAsync();
			return cmt;
		}

		public async Task<Comment> GetCommentByFuncId(int funcid)
		{
			return await _mainContext.Comments.FindAsync(funcid);
		}

		public async Task<Comment> GetCommentById(int id)
		{
			return await _mainContext.Comments.FindAsync(id);
		}

		public async Task<List<Comment>> GetListComment()
		{
			//return await _mainContext.Comments.ToListAsync();
			using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString(Main_Database)))
			{
				db.Open();
				IEnumerable<Comment> result = await db.QueryAsync<Comment>("select * from Comments");
				return result.ToList();
			}
		}

		public async Task<Comment> Update(Comment cmt)
		{
			_mainContext.Comments.Update(cmt);
			await _mainContext.SaveChangesAsync();
			return cmt;
		}
	}
}
