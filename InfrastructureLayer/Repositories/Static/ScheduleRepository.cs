using ApplicationLayer.Features.Schedule.Queries.GetAvailableSchedules;
using ApplicationLayer.Interfaces;
using DomainLayer.Converters;
using DomainLayer.Entities;
using DomainLayer.Helper_Classes;
using InfrastructureLayer.Context;
using InfrastructureLayer.Extensions;
using InfrastructureLayer.Repositories.Basic;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace InfrastructureLayer.Repositories.Static
{
    public class ScheduleRepository : GenericRepository<Schedule>, IScheduleRepository
    {
        #region Constructor(s)
        public ScheduleRepository(ApplicationDbContext context) : base(context)
        {

        }
        #endregion


        #region Action(s)
        //public async override Task<bool> UpdateAsync(Schedule entity)
        //{
        //    //entity.Class = _context.Set<Class>().Where(c => c.ClassName.Equals(entity.Class.ClassName)).First();
        //    //entity.ClassID = entity.Class.Id;
        //    _set.Update(entity);
        //    await _context.SaveChangesAsync();
        //    return true;
        //}
        public IQueryable<Schedule> GetActiveDaliySchedule(DayOfWeek day)
        {

            if (day.IsWeekEnd())
                _set.Where(s => false);

            string dayOfWeekString = DayConverter.Converter(day);

            return _set.Where(t => t.WeekSchedule.GetType().GetProperty(dayOfWeekString)!.GetValue(t.WeekSchedule, null) as bool? == true);

        }

        //Class Schedule
        public IQueryable<Schedule> GetClassSchedule(int ClassID) => _set.Where(sch => sch.ClassID.Equals(ClassID));

        public IQueryable<Schedule> GetClassSchedule(string ClassName) => _set.Where(sch => sch.Class.ClassName.Equals(ClassName));

        //Class Schedule History
        public IQueryable<Schedule> GetClassScheduleHistory(int ClassID) => _set.Where(sch => sch.ClassID.Equals(ClassID));

        public IQueryable<Schedule> GetClassScheduleHistory(string ClassName) => _set.Where(sch => sch.Class.ClassName.Equals(ClassName));

        public async Task<ICollection<WeekSchedule>> GetAvailableSchedules(GetAvailableSchedulesQueryDTO DTO)
        {
            // Map Schedule to SqlParameter list

            var sqlParameters = _AddGetAvailableSchedulesParameters(DTO);

            //Execution
            var result = await SP_AvailableSchedules_Execution(sqlParameters);

            //return the result
            return result;

        }

        #endregion

        #region Abstraction
        private async Task<List<WeekSchedule>> SP_AvailableSchedules_Execution(List<SqlParameter> sqlParameters)
        {
            var Schedules = new List<WeekSchedule>();

            // Open a database connection and execute the stored procedure
            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandType = CommandType.StoredProcedure;

                command.CommandText = "SP_GetAvailableSchedules ";

                command.Parameters.AddRange(sqlParameters.ToArray());

                await _context.Database.OpenConnectionAsync();

                using (var reader = await command.ExecuteReaderAsync())
                {

                    while (await reader.ReadAsync())
                        Schedules.Add(_MapWeekSchedule(reader));
                }



                return Schedules;
            }
        }

        private WeekSchedule _MapWeekSchedule(IDataReader reader)
        {
            return new WeekSchedule
            {
                SUN = reader.GetBoolean(reader.GetOrdinal("SUN")),
                MON = reader.GetBoolean(reader.GetOrdinal("MON")),
                TUE = reader.GetBoolean(reader.GetOrdinal("TUE")),
                WED = reader.GetBoolean(reader.GetOrdinal("WED")),
                THU = reader.GetBoolean(reader.GetOrdinal("THU"))

            };
        }

        private List<SqlParameter> _AddGetAvailableSchedulesParameters(GetAvailableSchedulesQueryDTO DTO)
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>
            {
                new SqlParameter("@StartTime"    , SqlDbType.Time    )        { Value = DTO.TimeSlot.StartTime           },
                new SqlParameter("@EndTime"      , SqlDbType.Time    )        { Value = DTO.TimeSlot.EndTime             },
                new SqlParameter("@ClassName"    , SqlDbType.NVarChar)        { Value = DTO.ClassName                    },
                new SqlParameter("@TimesPerWeek" , SqlDbType.TinyInt )        { Value = DTO.TimesPerWeek                 }

            };

            return sqlParameters;
        }

        #endregion




    }





}
