using System;

namespace ANCSG.Domain.Extensions
{
    public static class StringExtensions
    {
        public static T toEnum<T>(this string stringEnum) => (T)Enum.Parse(typeof(T), stringEnum, ignoreCase: true);
    }
}
