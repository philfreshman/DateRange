using Xunit;
using DateRange;

namespace DateRangeTests;

public class UnitTest
{
    [Theory]
    [InlineData("01.01.2017", "05.01.2017", "01 - 05.01.2017")]
    [InlineData("01.01.2017", "05.02.2017", "01.01 - 05.02.2017")]
    [InlineData("01.01.2016", "05.01.2017", "01.01.2016 - 05.01.2017")]
    public void Test(string firstDate, string secondDate, string expected)
    {
        string[] args = {firstDate, secondDate};
        var dateService = new DateService();
        var actual = dateService.GetDates(args);
        Assert.Equal(expected, actual);
    }
}