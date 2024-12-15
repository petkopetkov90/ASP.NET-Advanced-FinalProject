namespace FleetRouteManager.Common.Exceptions
{
    public class CustomDateFormatException(string propertyName, string message) : Exception(message)
    {
        public string PropertyName = propertyName;
    }
}
