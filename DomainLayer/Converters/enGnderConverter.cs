using DomainLayer.Enums;

namespace DomainLayer.Converters
{
    public static class enGnderConverter
    {
        public static bool Converter(enGender value)
            => value == enGender.Male ? false : true;
        public static enGender Converter(bool value)
            => value ? enGender.Female : enGender.Male;

    }

}
