using ApplicationLayer.Interfaces;
using DomainLayer.Entities;
using DomainLayer.Helper_Classes;
using InfrastructureLayer.Context;
using InfrastructureLayer.Repositories.Basic;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Data;

namespace InfrastructureLayer.Repositories.Static
{
    public class SectionRepository : GenericRepository<Section>, ISectionRepository
    {
        #region Constructure(s)
        public SectionRepository(ApplicationDbContext context) : base(context)
        {
        }

        #endregion

        #region Action(s)
        public override IQueryable<Section> GetById(int id)
            => _set.Where(s => s.Id.Equals(id) && s.IsOpen);

        public IQueryable<Section> GetByNumber(string sectionNumber)
            => _set.Where(s => s.SectionNumber.Equals(sectionNumber) && s.IsOpen);

        public async Task<bool> CloseAsync(string SectionNumber)
        {
            var affectedRows = await _set
          .Where(se => se.SectionNumber.Equals(SectionNumber))
          .ExecuteUpdateAsync(upd => upd.SetProperty(x => x.IsOpen, false));

            // Return true if any rows were affected, false otherwise
            return affectedRows > 0;

        }

        public async Task<bool> IsExistsByNumberAsync(string SectionNumber)
            => await _set.AnyAsync(s => s.SectionNumber.Equals(SectionNumber) && s.IsOpen);

        public async Task<bool> CheckSectionScheduleConflict(Schedule Schedule)
        {
            // Map Schedule to SqlParameter list

            List<SqlParameter> sqlParameters = Add_Check_Section_Conflict_Parameters(Schedule);

            //Execution
            var result = await SP_Check_Section_Conflict_Execution(sqlParameters);

            //return the result
            return result;

        }

        public async Task<bool> UpdateSectionSchedule(string sectionNumber, Schedule schedule)
        {

            var Section = GetByNumber(sectionNumber).Include(s => s.Schedule).ThenInclude(sch => sch.Class).AsNoTracking().FirstOrDefault();

            if (Section != null)
            {
                Section.Schedule = schedule;
                _set.Update(Section);

                await _context.SaveChangesAsync();

                return true;
            }
            return false;
            //_context.Set<Schedule>().Update(schedule);


        }

        public IQueryable<Schedule> GetSectionSchedule(string SectionNumber)
        {
            var scheduleID = _set.Where(s => s.SectionNumber.Equals(SectionNumber)).Select(s => s.ScheduleID).FirstOrDefault();

            return scheduleID != 0 ? _context.Set<Schedule>().Where(sch => sch.Id.Equals(scheduleID)) : _context.Set<Schedule>().Where(s => false);




        }


        public async Task<List<ScheduleConflict>> CheckTeacherSchedulConflict(string TeacherNumber, Schedule SectionSchedule)
        {
            // Map Schedule to SqlParameter list

            List<SqlParameter> sqlParameters = Add_Check_Teacher_Schedule_Conflict_Parameters(TeacherNumber, SectionSchedule);

            //Execution
            var result = await SP_Check_Teacher_Schedule_Conflict_Execution(sqlParameters);

            //return the result
            return result;
        }

        public async Task<bool> AssignSectionTeacher(string SectionNumber, int TeacherID)
        {
            return await _set.Where(s => s.SectionNumber.Equals(SectionNumber) && s.IsOpen)
                .ExecuteUpdateAsync(x => x.SetProperty(x => x.TeacherID, TeacherID)) > 0;
        }
        public IQueryable<Schedule> GetSectionSchedule(int SectionID)
            => _set.Where(s => s.Id.Equals(SectionID)).Select(s => s.Schedule);

        public IQueryable<Schedule> GetSectionScheduleHistory(int SectionID)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Schedule> GetSectionScheduleHistory(string SectionNumber)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Abstraction
        private List<SqlParameter> Add_Check_Section_Conflict_Parameters(Schedule schedule)
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>
            {
                new SqlParameter("@StartTime"  , SqlDbType.Time)     { Value = schedule.TimeSlot.StartTime           },
                new SqlParameter("@EndTime"    , SqlDbType.Time)     { Value = schedule.TimeSlot.EndTime             },
                new SqlParameter("@ClassName"  , SqlDbType.NVarChar) { Value = schedule.Class.ClassName              },
                new SqlParameter("@SUN"        , SqlDbType.Bit)      { Value = schedule.WeekSchedule.SUN             },
                new SqlParameter("@MON"        , SqlDbType.Bit)      { Value = schedule.WeekSchedule.MON             },
                new SqlParameter("@TUE"        , SqlDbType.Bit)      { Value = schedule.WeekSchedule.TUE             },
                new SqlParameter("@WED"        , SqlDbType.Bit)      { Value = schedule.WeekSchedule.WED             },
                new SqlParameter("@THU"        , SqlDbType.Bit)      { Value = schedule.WeekSchedule.THU             },
                new SqlParameter("@ANYCONFLICT", SqlDbType.Bit)      { Direction = ParameterDirection.Output         }

            };

            return sqlParameters;
        }

        private async Task<bool> SP_Check_Section_Conflict_Execution(List<SqlParameter> sqlParameters)
        {
            // Open a database connection and execute the stored procedure
            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandType = CommandType.StoredProcedure;

                command.CommandText = "SP_Check_Section_Conflict ";

                command.Parameters.AddRange(sqlParameters.ToArray());

                await _context.Database.OpenConnectionAsync();

                await command.ExecuteNonQueryAsync();

                var outputValue = (bool)command.Parameters["@ANYCONFLICT"].Value!;
                return outputValue;
            }
        }



        private List<SqlParameter> Add_Check_Teacher_Schedule_Conflict_Parameters(string TeacherNumber, Schedule schedule)
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>
            {
                new SqlParameter("@StartTime"    , SqlDbType.Time)            { Value = schedule.TimeSlot.StartTime           },
                new SqlParameter("@EndTime"      , SqlDbType.Time)            { Value = schedule.TimeSlot.EndTime             },
                new SqlParameter("@ClassName"    , SqlDbType.NVarChar)        { Value = schedule.Class.ClassName              },
                new SqlParameter("@SUN"          , SqlDbType.Bit)             { Value = schedule.WeekSchedule.SUN             },
                new SqlParameter("@MON"          , SqlDbType.Bit)             { Value = schedule.WeekSchedule.MON             },
                new SqlParameter("@TUE"          , SqlDbType.Bit)             { Value = schedule.WeekSchedule.TUE             },
                new SqlParameter("@WED"          , SqlDbType.Bit)             { Value = schedule.WeekSchedule.WED             },
                new SqlParameter("@THU"          , SqlDbType.Bit)             { Value = schedule.WeekSchedule.THU             },
                new SqlParameter("@TeacherNumber", SqlDbType.NVarChar)        { Value = TeacherNumber                         }

            };

            return sqlParameters;
        }

        private async Task<List<ScheduleConflict>> SP_Check_Teacher_Schedule_Conflict_Execution(List<SqlParameter> sqlParameters)
        {
            var Conflicts = new List<ScheduleConflict>();

            // Open a database connection and execute the stored procedure
            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandType = CommandType.StoredProcedure;

                command.CommandText = "SP_Check_Teacher_Schedule_Conflict ";

                command.Parameters.AddRange(sqlParameters.ToArray());

                await _context.Database.OpenConnectionAsync();

                using (var reader = await command.ExecuteReaderAsync())
                {

                    while (await reader.ReadAsync())
                        Conflicts.Add(_MapConflicts(reader));
                }



                return Conflicts;
            }
        }

        private ScheduleConflict _MapConflicts(IDataReader reader)
        {
            // Retrieve the section number
            string sectionNumber = reader.GetString(reader.GetOrdinal("SectionNumber"));

            // Create a BitArray for the week schedule
            var weekSchedule = new BitArray

            (
                new bool[5]
                {

                    reader.GetBoolean(reader.GetOrdinal("SUN")),
                    reader.GetBoolean(reader.GetOrdinal("MON")),
                    reader.GetBoolean(reader.GetOrdinal("TUE")),
                    reader.GetBoolean(reader.GetOrdinal("WED")),
                    reader.GetBoolean(reader.GetOrdinal("THU")),
                }
            );

            // Create an array of TimeSpan for the start and end times
            var timeSlot = new TimeSpan[2];
            timeSlot[0] = (TimeSpan)reader.GetValue(reader.GetOrdinal("StartTime")); // Start time
            timeSlot[1] = (TimeSpan)reader.GetValue(reader.GetOrdinal("EndTime"));   // End time

            // Create and return the ScheduleConflict object
            return new ScheduleConflict(sectionNumber, weekSchedule, timeSlot);



        }




        #endregion
    }
}
