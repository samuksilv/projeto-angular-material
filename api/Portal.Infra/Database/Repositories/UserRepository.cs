using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;
using Portal.Domain.Configurations;
using Portal.Domain.Contracts.Repositories;
using Portal.Domain.Models;
using Portal.Infra.Database.Constants.Queries;
using Portal.Infra.Database.Contexts;

namespace Portal.Infra.Database.Repositories {
    public class UserRepository : BaseRepository<User>, IUserRepository {
        public UserRepository (AppDbContext dbContext) : base (dbContext) { }

        public async override Task<User> GetByIdAsync (Guid id) {
            using (SqlConnection connection = new SqlConnection (DabaseConnectionConfiguration.ConnectionString)) {
                return await connection.QueryFirstOrDefaultAsync<User> (UserQueriesConstants.GetUserById, new { Id = id });
            }
        }

        public async Task<User> GetUserByEmailAsync (string email) {
            using (SqlConnection connection = new SqlConnection (DabaseConnectionConfiguration.ConnectionString)) {
                return await connection.QueryFirstOrDefaultAsync<User> (
                    UserQueriesConstants.GetUserByEmail,
                    new { Email = email }
                );
            }
        }

        public async Task<User> GetUserByEmailAndPasswordAsync (string email, string password) {
            using (SqlConnection connection = new SqlConnection (DabaseConnectionConfiguration.ConnectionString)) {
                return await connection.QueryFirstOrDefaultAsync<User> (
                    UserQueriesConstants.GetUserByEmailAndPassword,
                    new { Email = email, Password = password }
                );
            }
        }

    }
}