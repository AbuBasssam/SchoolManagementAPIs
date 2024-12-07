using DomainLayer.Enums;

namespace DomainLayer.Converters
{
    public static class enChangeTypeConverter
    {
        public static byte Converter(enChangeType value)
            => Convert.ToByte(value);
        public static enChangeType Converter(byte value)
            => (enChangeType)value;

    }
}
