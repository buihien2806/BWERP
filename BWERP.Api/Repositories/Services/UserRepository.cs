using BWERP.Api.EF;
using BWERP.Api.Entities;
using BWERP.Api.Repositories.Interfaces;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Ocsp;
using System.Data;

namespace BWERP.Api.Repositories.Services
{
	public class UserRepository : IUserRepository
	{
		private readonly MainContext _mainContext;
		//TEST ADO.NET
		private readonly IConfiguration _configuration;
		private const string Main_Database = "MainDBDatabase";
		//private const string SELECT_BUG = "select * from bugs";
		//
		public UserRepository(MainContext mainContext,
							 IConfiguration configuration)
		{
			_mainContext = mainContext;
			_configuration = configuration;
		}
		public async Task<List<AppUser>> GetListUser()
		{
			//return await _mainContext.Users.ToListAsync();
			IEnumerable<AppUser> employees;

			using (IDbConnection conn = new SqlConnection(_configuration.GetConnectionString(Main_Database)))
			{
				try
				{
					var readSql = "Select * from AppUsers";
					employees = await conn.QueryAsync<AppUser>(readSql);
				}
				catch (Exception ex)
				{
					throw ex;
				}
			}
			return employees.ToList();
		}

		public async Task<AppUser> Create(AppUser user)
		{
			await _mainContext.Users.AddAsync(user);
			await _mainContext.SaveChangesAsync();
			return user;
			//var parameters = new DynamicParameters();
			//parameters.Add("UserName", user.UserName, DbType.String);
			//parameters.Add("NormalizedUserName", user.NormalizedUserName, DbType.String);
			//parameters.Add("Email", user.Email, DbType.String);
			//parameters.Add("NormalizedEmail", user.NormalizedEmail, DbType.String);
			//parameters.Add("EmailConfirmed", user.EmailConfirmed, DbType.Boolean);
			//parameters.Add("PasswordHash", user.PasswordHash, DbType.String);
			//parameters.Add("SecurityStamp", user.SecurityStamp, DbType.String);
			//parameters.Add("FirstName", user.FirstName, DbType.String);
			//parameters.Add("LastName", user.LastName, DbType.String);
			//parameters.Add("isActive", user.isActive, DbType.Boolean);
			//parameters.Add("CreatedDate", user.CreatedDate, DbType.DateTime);
			//parameters.Add("LastLogin", user.LastLogin, DbType.DateTime);

			//using (IDbConnection conn = new SqlConnection(_configuration.GetConnectionString(Main_Database)))
			//{
			//	try
			//	{
			//		string insertSql = "INSERT INTO AppUsers (UserName, NormalizedUserName, Email, NormalizedEmail, EmailConfirmed, PasswordHash, SecurityStamp, FirstName, LastName, isActive, CreatedDate, LastLogin,AccessFailedCount)" +
			//			"VALUES (@UserName, @NormalizedUserName, @Email, @NormalizedEmail, @EmailConfirmed, @PasswordHash, @SecurityStamp, @FirstName, @LastName, @isActive, @CreatedDate, @LastLogin,0)";
			//		await conn.ExecuteAsync(insertSql, parameters);
			//	}
			//	catch (Exception ex)
			//	{
			//		throw ex;
			//	}
			//}
			//return user;
		}

		public async Task<AppUser> Delete(AppUser user)
		{
			//_mainContext.Users.Remove(user);
			//await _mainContext.SaveChangesAsync();
			//return user;
			var parameters = new DynamicParameters();
			parameters.Add("Id", user.Id, DbType.Guid);

			using (IDbConnection conn = new SqlConnection(_configuration.GetConnectionString(Main_Database)))
			{
				try
				{
					string deleteSql = "DELETE FROM AppUsers WHERE Id = @Id";
					await conn.ExecuteAsync(deleteSql, parameters);
				}
				catch (Exception ex)
				{
					throw ex;
				}
			}
			return user;
		}
		public async Task<AppUser> GetUserById(Guid id)
		{
			//return await _mainContext.Users.FindAsync(id);
			var parameters = new DynamicParameters();
			parameters.Add("Id", id, DbType.Guid);

			AppUser employee = new AppUser();

			using (IDbConnection conn = new SqlConnection(_configuration.GetConnectionString(Main_Database)))
			{
				try
				{
					string uSql = "Select * from AppUsers where Id = @Id";
					employee = await conn.QueryFirstOrDefaultAsync<AppUser>(uSql, parameters);
				}
				catch (Exception ex)
				{
					throw ex;
				}
			}
			return employee;
		}

		public async Task<AppUser> Update(AppUser user)
		{
			//_mainContext.Users.Update(user);
			//await _mainContext.SaveChangesAsync();
			//return user;
			var parameters = new DynamicParameters();
			parameters.Add("Id", user.Id, DbType.Guid);
			parameters.Add("FirstName", user.FirstName, DbType.String);
			parameters.Add("LastName", user.LastName, DbType.String);
			parameters.Add("isActive", user.isActive, DbType.Boolean);

			using (IDbConnection conn = new SqlConnection(_configuration.GetConnectionString(Main_Database)))
			{
				try
				{
					string updateSql = "UPDATE AppUsers SET FirstName = @FirstName, LastName = @LastName, isActive = @isActive WHERE Id = @Id";
					await conn.ExecuteAsync(updateSql, parameters);
				}
				catch (Exception ex)
				{
					throw ex;
				}
			}
			return user;
		}
	}
}
