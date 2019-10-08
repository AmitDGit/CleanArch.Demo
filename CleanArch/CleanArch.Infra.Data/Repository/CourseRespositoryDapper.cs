using CleanArch.Domain.Interfaces;
using CleanArch.Domain.Models;
using CleanArch.Infra.Data.Dapper;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CleanArch.Infra.Data.Repository
{
    public class CourseRespositoryDapper : ICourseRepository
    {
        private DBConnectionFactory _dbConnectionFactory;


        public CourseRespositoryDapper(DBConnectionFactory dBConnectionFactory)
        {
            _dbConnectionFactory = dBConnectionFactory;
        }

        public void Add(Course course)
        {
            string procName = "sproc_Courses_ups";
            var paramName = new DynamicParameters();

            paramName.Add("@Name",course.Name);
            paramName.Add("@Description", course.Description);
            paramName.Add("@ImageURL", course.ImageURL);

            SqlMapper.Execute(_dbConnectionFactory.GetConnection,
                procName, paramName, commandType: System.Data.CommandType.StoredProcedure);

            _dbConnectionFactory.CloseConnection();

        }

        public IQueryable<Course> GetCourses()
        {
            var sqlQuery = @"SELECT [Id]      ,[Name]      ,[Description]      ,[ImageURL]  FROM [UniversityDB].[dbo].[Courses]";

            using (var conn = _dbConnectionFactory.GetConnection)
            {
                var result = conn.Query<Course>(sqlQuery);
                return result.AsQueryable();
            }

        }
    }
}
