using DomainLayer.Enums;

namespace DomainLayer.Converters
{
    public static class enLevelConverter
    {
        public static byte Converter(enLevel value)
            => Convert.ToByte(value);
        public static enLevel Converter(byte value)
            => (enLevel)value;

    }
}
