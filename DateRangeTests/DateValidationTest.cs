using System;
using Xunit;
using DateRange;

namespace DateRangeTests;

public class UnitTest
{
    private readonly Validator _validator;
    public UnitTest()
    {
        _validator = new Validator();
    }
    
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ", " ", " ")]
    public void CheckEntryPointLength(params string?[] args)
    {
        var exception = Record.Exception(() => _validator.CheckEntryPointLength(args));
        Assert.NotNull(exception);
    }
    
    [Theory]
    [InlineData(null)]
    [InlineData(null, null)]
    [InlineData(null, "HelloWorld")]
    [InlineData("01.02.2021", null)]
    public void CheckIfInputEmpty(params string?[] args)
    {
        var exception = Record.Exception(() => _validator.CheckIfInputEmpty(args));
        Assert.NotNull(exception);
    }
    
    [Theory]
    [InlineData("1,1,1","2,2,2")]
    [InlineData("2021-2021-01","2021/2021/01")]
    [InlineData("Fri 29 Aug","Fri 30 Aug")]
    [InlineData("29 August","30 August")]
    public void DateParseCheck(params string?[] args)
    {
        var exception = Record.Exception(() => _validator.DateParseCheck(args));
        Assert.NotNull(exception);
    }
    
    [Theory]
    [InlineData("1-1-1", "1-1-1")]
    [InlineData("01/01/01", "01/01/01")]
    [InlineData("01.01.2021", "01.01.2021")]
    public void IsSecondBigger(params string?[] args)
    {
        var exception = Record.Exception(() => _validator.IsSecondBigger(args));
        Assert.NotNull(exception);
    }
}