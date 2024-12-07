using ApplicationLayer.Interfaces;
using DomainLayer.Converters;
using DomainLayer.Entities;
using DomainLayer.Enums;
using InfrastructureLayer.Context;
using InfrastructureLayer.Repositories.Basic;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace InfrastructureLayer.Repositories.ReadOnly
{
    public class ClassRepository : ReadOnlyRepository<Class>, IClassRepository
    {
        #region Constructor(s)
        public ClassRepository(ApplicationDbContext context) : base(context)
        {

        }
        #endregion

        #region Action(s)

        public IQueryable<Class> GetByName(string ClassName) => _set.Where(x => x.ClassName == ClassName);

        public async Task<IList<Class>> GetClassesFilter(FilterClasses filter)
        {
            // Map FilterClasses to SqlParameter list
            List<SqlParameter> sqlParameters = _SQLFilterParameters(filter);

            // Initialize the result List
            List<Class> classes = new List<Class>();

            //Execution
            await SP_Execution(sqlParameters, classes);

            //return the result
            return classes;

        }

        #endregion

        #region Abstraction
        private async Task SP_Execution(List<SqlParameter> sqlParameters, List<Class> classes)
        {
            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "SP_Classes_Filter";

                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddRange(sqlParameters.ToArray());

                await _context.Database.OpenConnectionAsync();
                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                        classes.Add(_ClassMap(reader));

                }
            }
        }


        #endregion

        #region Abstraction
        private List<SqlParameter> _SQLFilterParameters(FilterClasses filter)
        {
            return new List<SqlParameter>
            {
                new SqlParameter("@ClassType", filter.Type.HasValue ? enTypeConverter.Converter(filter.Type.Value) : DBNull.Value),
                new SqlParameter("@ClassCapacity", filter.Capacity.HasValue ? filter.Capacity.Value : DBNull.Value),
                new SqlParameter("@ComparisonType", Convert.ToByte(filter.ComparisonType)),

            };
        }

        private Class _ClassMap(IDataReader reader)
        {
            return new Class
            {
                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                ClassName = reader.GetString(reader.GetOrdinal("ClassName")),
                ClassCapacity = reader.GetByte(reader.GetOrdinal("ClassCapacity")),
                ClassType = reader.GetBoolean(reader.GetOrdinal("ClassType")) ? enType.Practical : enType.Theory,

            };
        }

        public async Task<bool> IsExistsByName(string className)
         => await _set.AnyAsync(c => c.ClassName.Equals(className));

        #endregion
    }
}

