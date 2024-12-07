using DomainLayer.Enums;

namespace DomainLayer.Converters
{
    public static class enSemesterTypeConverter
    {
        public static byte Converter(enSemesterType value)
            => Convert.ToByte(value);
        public static enSemesterType Converter(byte value)
            => (enSemesterType)value;

    }
}
