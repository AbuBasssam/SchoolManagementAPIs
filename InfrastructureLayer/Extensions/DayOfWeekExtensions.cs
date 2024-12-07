using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer.Extensions
{
    
    public static class DayOfWeekExtensions
    {
        public static bool IsWeekEnd(this DayOfWeek value) => value == DayOfWeek.Friday || value == DayOfWeek.Saturday;


        public static bool IsWeekDay(this DayOfWeek value) => !IsWeekEnd(value);

        

    }


}
