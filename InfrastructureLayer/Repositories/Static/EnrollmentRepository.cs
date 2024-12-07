using ApplicationLayer.Features.Enrollment.Queries.GetAvailableEnrollmentCourses;
using DomainLayer.Entities;
using DomainLayer.Enums;
using InfrastructureLayer.Context;
using InfrastructureLayer.Repositories.Basic;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace InfrastructureLayer.Repositories.Static
{
    public class EnrollmentRepository : GenericRepository<Enrollment>, IEnrollmentRepository
    {
        #region Constructor(s)
        public EnrollmentRepository(ApplicationDbContext context) : base(context) { }

        public async Task<bool> AnySectionScheduleConflict(string StudentNumber, string SectionNumber)
        {
            //Map parameters to sql parameters

            List<SqlParameter> sqlParameters = _GetAnySectionScheduleConflictParameters(StudentNumber, SectionNumber);

            //Execution
            var result = await SP_AnySectionScheduleConflictExecution(sqlParameters);

            //return the result
            return result;
        }

        #endregion
        public async Task<IList<AvailableEnrollmentCoursesDTO>> GeAvailableEnrollmentCourses(string StudentNumber)
        {

            //Map parameters to sql parameters

            SqlParameter sqlParameters = _GetAvailableEnrollmentCoursesParameter(StudentNumber);

            //Execution
            var result = await SP_Execution(sqlParameters);

            //return the result
            return result;


        }

        public async Task<bool> IsAlreadyEnrolled(string StudentNumber, string courseCode)
        {

            return await _set.AnyAsync(
                s => s.Student.UserInfo.UserName!.Equals(StudentNumber) && s.Section.Course.CourseCode.Equals(courseCode)
                && (s.IsStudentPass == null));

        }
        public async Task<bool> IsAlreadyPassed(string StudentNumber, string courseCode)
        {

            return await _set.AnyAsync(
                s => s.Student.UserInfo.UserName!.Equals(StudentNumber) && s.Section.Course.CourseCode.Equals(courseCode) && s.IsStudentPass == true);

        }


        #region Abstraction
        private SqlParameter _GetAvailableEnrollmentCoursesParameter(string StudentNumber)
           => new SqlParameter("@StudentNumber", StudentNumber);

        private async Task<IList<AvailableEnrollmentCoursesDTO>> SP_Execution(SqlParameter sqlParameter)
        {
            // Open a database connection and execute the stored procedure
            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "SP_Get_Available_Enrollment_Courses";

                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(sqlParameter);

                await _context.Database.OpenConnectionAsync();

                var courses = new List<AvailableEnrollmentCoursesDTO>();
                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                        courses.Add(_AvailableEnrollmentCoursesMap(reader));
                }


                return courses;
            }

        }

        private AvailableEnrollmentCoursesDTO _AvailableEnrollmentCoursesMap(IDataReader reader)
        {
            return new AvailableEnrollmentCoursesDTO(

                reader.GetString(reader.GetOrdinal("CourseCode")),
                reader.GetString(reader.GetOrdinal("CourseName")),
                (enCourseHours)reader.GetByte(reader.GetOrdinal("CourseHours")),
                (enLevel)reader.GetByte(reader.GetOrdinal("CourseLevel"))


            );
        }
        #endregion

        private List<SqlParameter> _GetAnySectionScheduleConflictParameters(string StudentNumber, string SectionNumber)
        {
            return new List<SqlParameter>
            {
                new SqlParameter("@StudentNumber",SqlDbType.NVarChar) { Value = StudentNumber                },
                new SqlParameter("@SectionNumber",SqlDbType.NVarChar) { Value = SectionNumber                },
                new SqlParameter("@AnyConflict",  SqlDbType.Bit     ) { Direction = ParameterDirection.Output}

            };
        }

        private async Task<bool> SP_AnySectionScheduleConflictExecution(List<SqlParameter> sqlParameters)
        {
            // Open a database connection and execute the stored procedure
            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandType = CommandType.StoredProcedure;

                command.CommandText = "SP_GetSectionEnrollmentConflict ";

                command.Parameters.AddRange(sqlParameters.ToArray());

                await _context.Database.OpenConnectionAsync();

                await command.ExecuteNonQueryAsync();

                var outputValue = (bool)command.Parameters["@AnyConflict"].Value!;
                return outputValue;
            }
        }

        public IQueryable<Enrollment> GetEnrollment(string StudentNumber, string SectionNumber)
        => _set.Where(e => e.Student.UserInfo.UserName!.Equals(StudentNumber) && e.Section.SectionNumber.Equals(SectionNumber) && e.IsStudentPass == null);


    }



}