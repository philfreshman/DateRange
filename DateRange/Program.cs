namespace DateRange;
static class Program
{
    static void Main(string[] args)
    {
        try
        {
            var dateService = new DateService();
            var result = dateService.GetDates(args);
            Console.WriteLine(result);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}