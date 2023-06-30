namespace MyInterview.Test;

public class LeonardosPrimeFactors
{
    public static long Run(long[] primes, long n)
    {
        long ret = 0;
        if (n <= 1) return 0;
        if (n <= 3) return 1;
        for (int i = 2; i < primes.Length; i++)
        {
            n /= primes[i - 2];
            if (n == 0) break;
            ret++;
        }

        return ret;
    }
}

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