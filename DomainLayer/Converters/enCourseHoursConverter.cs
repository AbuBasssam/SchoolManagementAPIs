using DomainLayer.Enums;

namespace DomainLayer.Converters
{
    public static class enCourseHoursConverter
    {
        public static byte Converter(enCourseHours value)
            => Convert.ToByte(value);
        public static enCourseHours Converter(byte value)
            => (enCourseHours)value;

    }

}
