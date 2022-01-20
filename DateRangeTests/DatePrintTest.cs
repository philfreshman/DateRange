using System;
using DateRange;
using Xunit;

namespace DateRangeTests;


public class DatePrintTest
{
     [Theory]
     [InlineData("01.01.2017", "05.01.2017", "01 - 05.01.2017")]
     [InlineData("2017-01-01", "2017-03-02", "01.01 - 02.03.2017")]
     [InlineData("01/01/2016", "05/01/2017", "01.01.2016 - 05.01.2017")]
     [InlineData("2021 01 01", "2022 02 02", "01.01.2021 - 02.02.2022")]
     public void Test( string firstDate, string secondDate, string expected)
     {
         string[] dates = {firstDate, secondDate};
         var dateService = new DateService();
         var datesAdd = dateService.ParseDates(dates);
         
         var timeSpan = new RangeService();
         var actualResult = timeSpan.GetTimeSpan(datesAdd);
         Assert.Equal(expected, actualResult);
     }
}