using System.Globalization;

namespace DateRange;

public class Validator
{
    public void CheckAll(string[] args)
    {
        CheckEntryPointLength(args);
        CheckIfInputEmpty(args);
        DateParseCheck(args);
        IsSecondBigger(args);
    }

    public void CheckEntryPointLength(string[] dateStringPair)
    {
        if (dateStringPair.Length != 2)
            throw new Exception("Error: Wrond input - please provide 2 seperate dates in dd-mm-yyyy format.\nTry again.");
    }

    public void CheckIfInputEmpty(string[] dateStringPair)
    {
        if (dateStringPair[0].Length == 0 || dateStringPair[1].Length == 0)
            throw new Exception("Error: No input provided.\nTry again.");
    }

    public void DateParseCheck(string[] dateStringPair)
    {
        var dateFormats = Globals.SupportedDateFormats;
                            
        var parseSucceded = DateTime.TryParseExact(dateStringPair[0], dateFormats, DateTimeFormatInfo.InvariantInfo,
                                DateTimeStyles.None, out _)
                            && DateTime.TryParseExact(dateStringPair[1], dateFormats, DateTimeFormatInfo.InvariantInfo,
                                DateTimeStyles.None, out _);
        if (!parseSucceded)
            throw new Exception(
                "Error: Date format not supported.\n Try again with one of the folowing formats:\ndd.MM.yyyy\ndd-mm-yyyy\ndd/MM/yyyy\nyyyy-MM-dd\nMM-yyyy-dd\nyyyy MM dd");
    }

    public void IsSecondBigger(string[] dateStringPair)
    {
        var date1 = DateTime.Parse(dateStringPair[0]);
        var date2 = DateTime.Parse(dateStringPair[1]);
        var difference = DateTime.Compare(date1, date2);

        if (difference >= 0)
            throw new Exception("Error: Second date must be bigger.\nTry again.");
    }
}