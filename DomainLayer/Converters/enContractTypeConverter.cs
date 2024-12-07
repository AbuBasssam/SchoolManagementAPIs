using DomainLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Converters
{
    public static class enContractTypeConverter
    {
        public static bool Converter(enContractType value)
            => value == enContractType.FullTime;
        public static enContractType Converter(bool value)
            => value ? enContractType.FullTime : enContractType.PartTime;

    }

}
