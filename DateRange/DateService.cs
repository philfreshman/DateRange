using System.Globalization;

namespace DateRange;

public class DateService : IDateService
{
    public string? GetDates(string[] args)
    {
        if (args?.Length != 2)
            throw new Exception("Error: Wrong input - please provide 2 seperate dates in dd-mm-yyyy format.\nTry again.");

        if (string.IsNullOrEmpty(args[0]) || string.IsNullOrEmpty(args[1]))
            throw new Exception("Error: No input provided.\nTry again.");

        if (!DateTime.TryParseExact(args[0], "dd.MM.yyyy", DateTimeFormatInfo.InvariantInfo, DateTimeStyles.None, out DateTime date1)
            || !DateTime.TryParseExact(args[1], "dd.MM.yyyy", DateTimeFormatInfo.InvariantInfo, DateTimeStyles.None, out DateTime date2))
        {
            throw new Exception("Error: Wrong date format provided - please use the dd-mm-yyyy format.\nTry again.");
        }

        var difference = DateTime.Compare(date1, date2);
        if (difference >= 0)
            throw new Exception("Error: Second date must be bigger.\nTry again.");

        return GetTimeSpanString(date1, date2);
    }

    private string? GetTimeSpanString(DateTime date1, DateTime date2)
    {
        var isMonthDiff = date2.Month - date1.Month != 0;
        var isYearDiff = date2.Year - date1.Year != 0;

        string timeSpanString;
        if (isYearDiff)
        {
            timeSpanString = $"{date1:dd.MM.yyyy} - {date2:dd.MM.yyyy}";
        }
        else if (isMonthDiff && !isYearDiff)
        {
            timeSpanString = $"{date1:dd.MM} - {date2:dd.MM.yyyy}";
        }
        else
        {
            timeSpanString = $"{date1.Day:00} - {date2:dd.MM.yyyy}";
        }
        return timeSpanString;
    }

}