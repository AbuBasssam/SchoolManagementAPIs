namespace DomainLayer.Converters
{
    public static class DayConverter
    {
        public static string Converter(DayOfWeek value)
        {
            switch (value)  
            {
                case DayOfWeek.Sunday:
                    return "SUN";
                    
                
                case DayOfWeek.Monday:
                    return "MON";
                
                case DayOfWeek.Tuesday:
                    return"TUE";
                
                case DayOfWeek.Wednesday:
                    return"WED";
                
                case DayOfWeek.Thursday:
                    return"THU";
                
                case DayOfWeek.Friday:
                    return"FRI";
                
                case DayOfWeek.Saturday:
                    return "SAT";
                
                default:
                    return string.Empty;
            }
        }
        
    }
}
