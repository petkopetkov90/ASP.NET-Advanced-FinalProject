using FleetRouteManager.Common.Exceptions;
using System.Globalization;

using static FleetRouteManager.Common.ErrorMessages.ExceptionMessages;

namespace FleetRouteManager.Common.Parsers
{
    public static class CustomDateParsers
    {
        public static DateTime CustomStringToDateParseExact(string dateString, string dateFormat, string fieldName)
        {
            try
            {
                return DateTime.ParseExact(dateString, dateFormat, CultureInfo.InvariantCulture);
            }
            catch (FormatException)
            {
                throw new CustomDateFormatException(fieldName, string.Format(InvalidDateExceptionMsg, dateString, dateFormat));
            }
        }
        public static DateTime? CustomNullableStringToDateParseExact(string? dateString, string dateFormat, string fieldName)
        {
            if (string.IsNullOrWhiteSpace(dateString))
            {
                return null;
            }

            return CustomStringToDateParseExact(dateString, dateFormat, fieldName);
        }

        public static string? CustomNullableDateToStringParseExact(DateTime? date, string dateFormat)
        {
            if (date == null)
            {
                return null;
            }

            return CustomDateToStringParseExact(date.Value.Date, dateFormat);
        }

        public static string CustomDateToStringParseExact(DateTime date, string dateFormat)
        {
            return date.ToString(dateFormat);
        }
    }
}
