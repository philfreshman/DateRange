using System.Globalization;

namespace DateRange;

public class DateService
{
    public DateTime[] ParseDates(string[] args)
    {
        var dateFormats = Globals.SupportedDateFormats;
        var date1 = DateTime.ParseExact(args[0], dateFormats, DateTimeFormatInfo.InvariantInfo);
        var date2 = DateTime.ParseExact(args[1], dateFormats, DateTimeFormatInfo.InvariantInfo);

        DateTime[] dates = {date1, date2};
        
        return dates;
    }
}