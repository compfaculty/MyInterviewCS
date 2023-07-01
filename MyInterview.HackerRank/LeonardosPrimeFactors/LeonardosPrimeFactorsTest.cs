namespace MyInterview.Test.LeonardosPrimeFactors;

public class LeonardosPrimeFactorsTest
{
    [Theory]
    [InlineData(new long[] { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59 }, 5, 1)]
    public void TestRun(long[] data, long n, long retVal)
    {
        var res = LeonardosPrimeFactors.Run(data, n);
        Assert.Equal(retVal, res);
    }
}