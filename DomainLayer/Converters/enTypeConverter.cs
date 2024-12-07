using DomainLayer.Enums;

namespace DomainLayer.Converters
{
    public static class enTypeConverter
    {
        public static bool Converter(enType value)
            => value == enType.Practical;

        public static enType Converter(bool value)
            => value ? enType.Practical : enType.Theory;

    }



}
