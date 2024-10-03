namespace RestaurantBookingSystem.Helpers
{
    public static class DateAndTimeHelper
    {
        public static DateTime ToSwedishTime(DateTime utcTime)
        {
            TimeZoneInfo sweden = TimeZoneInfo.FindSystemTimeZoneById("Europe/Stockholm");
            DateTime swedishTime = TimeZoneInfo.ConvertTimeFromUtc(utcTime, sweden);

            return swedishTime;
        }
    }
}
