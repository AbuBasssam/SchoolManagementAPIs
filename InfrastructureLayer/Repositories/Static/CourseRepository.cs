using ApplicationLayer.Features.Courses.Queries.GetCoursesFilterPage;
using ApplicationLayer.Models;
using DomainLayer.Entities;
using DomainLayer.Enums;
using InfrastructureLayer.Context;
using InfrastructureLayer.Repositories.Basic;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Data.Common;

namespace InfrastructureLayer.Repositories.Static
{
    public class CourseRepository : StaticGenericRepository<Course>, ICourseRepository
    {
        #region Constructor(s)
        public CourseRepository(ApplicationDbContext context) : base(context) { }

        #endregion

        #region Actions
        public override IQueryable<Course> GetById(int id) => _set.Where(s => s.Id.Equals(id)).Include(s => s.PrerequisiteCourse);

        public IQueryable<Course> GetByCode(string CourseCode) => _set.Where(s => s.CourseCode.Equals(CourseCode)).Include(s => s.PrerequisiteCourse);

        public IQueryable<Course> GetByName(string CourseName) => _set.Where(s => s.CourseName.Equals(CourseName)).Include(s => s.PrerequisiteCourse);

        public async Task<bool> IsExistsByCodeAsync(string CourseCode) => await _set.AnyAsync(s => s.CourseCode.Equals(CourseCode));

        public async Task<bool> IsExistsByNameAsync(string CourseName) => await _set.AnyAsync(s => s.CourseName.Equals(CourseName));

        public async Task<bool> IsPrerequisiteAlreadyExistsAsync(string CourseCode) => await _set.AnyAsync(s => s.PrerequisiteCourse!.CourseCode.Equals(CourseCode));

        public async Task<PagedCourseResult> GetCoursesFilter(CourseFilter filter, FilterInfo filterInfo)
        {
            // Map CourseFilter to SqlParameter list
            List<SqlParameter> sqlParameters = AddParameters(filter, filterInfo);

            // Initialize the result object
            var result = new PagedCourseResult();

            //Execution
            await SP_Execution(sqlParameters, result);

            //return the result
            return result;

        }

        /* public async override Task<int> AddAsync(Course entity)
         {
             if (entity.PrerequisiteCourse is not null)
             {
                 var Course = _set.Where(c => c.CourseCode.Equals(entity.PrerequisiteCourse!.CourseCode)).First();
                 entity.PrerequisiteCourse = Course;
                 entity.PrerequisiteID = Course.Id;
             }


             await _set.AddAsync(entity);
             await _context.SaveChangesAsync();
             return entity.Id;
         }
 */
        #endregion

        #region Abstraction

        private List<SqlParameter> AddParameters(CourseFilter filter, FilterInfo filterInfo)
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>()
            {
                new SqlParameter("@PageNumber"     , filterInfo. PageNumber                         ),
                new SqlParameter("@PageSize"       , filterInfo.PageSize                            ),
                new SqlParameter("@CourseHours"    , filter.CourseHours ?? (object)DBNull.Value     ),
                new SqlParameter("@CourseLevel"    , filter.CourseLevel ?? (object)DBNull.Value     ),
                new SqlParameter("@HasPractical"   , filter.HasPractical ?? (object)DBNull.Value    ),
                new SqlParameter("@HasPrerequisite", filter.HasPrerequisite ?? (object)DBNull.Value )
            };

            return sqlParameters;
        }

        private async Task SP_Execution(List<SqlParameter> sqlParameters, PagedCourseResult result)
        {
            // Open a database connection and execute the stored procedure
            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "SP_Courses_Filter";

                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddRange(sqlParameters.ToArray());

                await _context.Database.OpenConnectionAsync();

                using (var reader = await command.ExecuteReaderAsync())
                {
                    await FillFilterResult(result, reader);
                    await GetFilterResultInfo(result, reader);
                }
            }
        }

        private async Task GetFilterResultInfo(PagedCourseResult result, DbDataReader reader)
        {
            // Move to the second result set
            await reader.NextResultAsync();

            // Second result set: Read TotalCount and PageCount
            if (await reader.ReadAsync())
            {
                result.TotalCount = reader.GetInt32(reader.GetOrdinal("TotalCount"));
                result.PageCount = reader.GetInt32(reader.GetOrdinal("PageCount"));

            }
        }

        private async Task FillFilterResult(PagedCourseResult result, DbDataReader reader)
        {
            // First result set: Read the list of courses
            var courses = new List<Course>();

            while (await reader.ReadAsync())
                courses.Add(_CourseMap(reader));

            result.Courses = courses;
        }

        private Course _CourseMap(IDataReader reader)
        {
            return new Course
            {
                CourseCode = reader.GetString(reader.GetOrdinal("CourseCode")),
                CourseName = reader.GetString(reader.GetOrdinal("CourseName")),
                CourseHours = (enCourseHours)reader.GetByte(reader.GetOrdinal("CourseHours")),
                CourseLevel = (enLevel)reader.GetByte(reader.GetOrdinal("CourseLevel")),
                HasPractical = reader.GetBoolean(reader.GetOrdinal("HasPractical")),
                HasPrerequisite = reader.GetBoolean(reader.GetOrdinal("HasPrerequisite")),
                PrerequisiteCourse = reader.IsDBNull(reader.GetOrdinal("PrerequisiteCourseCode")) ? null
                : new Course { CourseCode = reader.GetString(reader.GetOrdinal("PrerequisiteCourseCode")) }

            };
        }
        #endregion


    }
}
