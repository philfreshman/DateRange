namespace DateRange;

public class RangeService
{
    private static DateTime firstDate;
    private static DateTime secondDate;
    private static bool isMonthDiff;
    private static bool isYearDiff;
    
    public static void InspectDates(DateTime[] datesArr)
    {
        // No day-level check - validator already checked if the second date is bigger.
        firstDate = datesArr[0];
        secondDate = datesArr[1];
        
        isMonthDiff = secondDate.Month - firstDate.Month != 0;
        isYearDiff = secondDate.Year - firstDate.Year != 0;
    }
    
    public string? GetTimeSpan(DateTime[] datesArr)
    {
        InspectDates(datesArr);
        
        var timeSpanString = String.Empty;
        
        if (isYearDiff)
        {
            timeSpanString += $"{firstDate:dd.MM.yyyy} - {secondDate:dd.MM.yyyy}";
        }
        else if (isMonthDiff && !isYearDiff )
        {
            timeSpanString += $"{firstDate:dd.MM} - {secondDate:dd.MM.yyyy}";
        }
        else
        {
            timeSpanString += $"{firstDate.Day:00} - {secondDate:dd.MM.yyyy}";
        }

        return timeSpanString;
    }
}
