namespace CacheHeaders.Caching;

public static class EtagExtensions
{
    // ETags can be any data, but using Last modified dates
    // are always a good indicator that a model has changed
    public static string ToEtag(this DateTimeOffset dateTimeOffset)
    {
        var dateBytes = BitConverter.GetBytes(dateTimeOffset.UtcDateTime.Ticks);
        var offsetBytes = BitConverter.GetBytes((short) dateTimeOffset.Offset.TotalHours);
        return Convert.ToBase64String(dateBytes.Concat(offsetBytes).ToArray());
    }
}