
namespace DateRange;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            var validator = new Validator();
            validator.CheckAll(args);
            
            var dateService = new DateService();
            var datesAdd = dateService.ParseDates(args);

            var timeSpan = new RangeService();
            var timeResult = timeSpan.GetTimeSpan(datesAdd);
            Console.WriteLine(timeResult);
        }
        
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}