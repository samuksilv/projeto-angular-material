using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;
using Portal.Domain.Configurations;
using Portal.Domain.Contracts.Repositories;
using Portal.Domain.Models;
using Portal.Infra.Database.Contants.Queries;
using Portal.Infra.Database.Contexts;

namespace Portal.Infra.Database.Repositories {
    public class SegmentRepository : BaseRepository<Segment>, ISegmentRepository {
        public SegmentRepository (AppDbContext dbContext) : base (dbContext) { }

        public async Task<IEnumerable<Segment>> GetAllAsync () {
            using (SqlConnection connection = new SqlConnection (DabaseConnectionConfiguration.ConnectionString)) {
                return await connection.QueryAsync<Segment> (SegmentQueries.GetAll);
            }
        }

        public async override Task<Segment> GetByIdAsync (Guid id) {
            using (SqlConnection connection = new SqlConnection (DabaseConnectionConfiguration.ConnectionString)) {
                return await connection.QueryFirstOrDefaultAsync<Segment> (
                    SegmentQueries.GetById,
                    new { Id = id }
                );
            }
        }

        public async Task<IEnumerable<Segment>> GetPaginatedWithFilterAsync (string description, int page, int pageSize) {

            using (SqlConnection connection = new SqlConnection (DabaseConnectionConfiguration.ConnectionString)) {

                int offset = page * pageSize;

                return await connection.QueryAsync<Segment> (SegmentQueries.GetAllPaginatedWithFilter (description),
                    new {
                        Offset = offset,
                        PageSize = pageSize,
                        Description = description,
                    }
                );

            }
        }

        public async Task<IEnumerable<Segment>> GetFilterByDescriptionAsync (string description) {
            using (SqlConnection connection = new SqlConnection (DabaseConnectionConfiguration.ConnectionString)) {

                return await connection.QueryAsync<Segment> (SegmentQueries.GetAllFilterByDescription,
                    new { Description = description }
                );
            }
        }

        public async Task<int> Count (string description) {
            using (SqlConnection connection = new SqlConnection (DabaseConnectionConfiguration.ConnectionString)) {

                return await connection.ExecuteScalarAsync<int> (SegmentQueries.CountWithFilter (description), new { Description = description });
            }
        }
    }
}