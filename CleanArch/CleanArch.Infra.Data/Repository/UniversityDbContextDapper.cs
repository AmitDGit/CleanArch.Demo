using CleanArch.Domain.Interfaces;
using CleanArch.Domain.Models;
using CleanArch.Infra.Data.Dapper;
using Dapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArch.Infra.Data.Repository
{
    public class UniversityDbContextDapper : IUniversityDbContext
    {
        private DBConnectionFactory _dbConnectionFactory;

        public UniversityDbContextDapper(DBConnectionFactory dBConnectionFactory)
        {
            _dbConnectionFactory = dBConnectionFactory;
        }

        public async Task<IEnumerable<Course>> GetAllCourses(CancellationToken cancellectionToken)
        {
            var sqlQuery = @"SELECT [Id]      ,[Name]      ,[Description]      ,[ImageURL]  FROM [UniversityDB].[dbo].[Courses]";

            using (var conn = _dbConnectionFactory.GetConnection)
            {
                var result = await conn.QueryAsync<Course>(sqlQuery);
                return result;
            }

        }
    }
}
