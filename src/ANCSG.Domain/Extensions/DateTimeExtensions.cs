using System;

namespace ANCSG.Domain.Extensions
{
    public static class DateTimeExtensions
    {
        public static string ToDateFormat(this DateTime date) => date.ToString("dd/MM/yyyy");

        public static string ToTimeFomat(this DateTime date) => date.ToString("HH:mm");
    }
}
