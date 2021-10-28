using System;

public static class DateTimeExtensions
{
    private const string DATE_TIME_FULL_FORMAT = "yyyy-MM-ddTHH:mm:ss.fffffffK";

    public static string ToFullString(this DateTime value)
        => value.ToString(DATE_TIME_FULL_FORMAT);
}
