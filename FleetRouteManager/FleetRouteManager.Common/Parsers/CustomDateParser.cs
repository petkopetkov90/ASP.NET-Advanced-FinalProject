using FleetRouteManager.Common.Exceptions;
using System.Globalization;

using static FleetRouteManager.Common.ErrorMessages.VehicleErrorMessages;

namespace FleetRouteManager.Common.Parsers
{
    public static class CustomDateParser
    {
        public static DateTime CustomDateParseExact(string dateString, string dateFormat, string fieldName)
        {
            try
            {
                return DateTime.ParseExact(dateString, dateFormat, CultureInfo.InvariantCulture);
            }
            catch (FormatException)
            {
                throw new CustomDateFormatException(fieldName, string.Format(InvalidDate, dateString, dateFormat));
            }
        }
        public static DateTime? CustomNullableDateParseExact(string dateString, string dateFormat, string fieldName)
        {
            if (string.IsNullOrEmpty(dateString))
            {
                return null;
            }

            return CustomDateParseExact(dateString, dateFormat, fieldName);
        }
    }
}
