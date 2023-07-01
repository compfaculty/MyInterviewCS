namespace MyInterview.Test.LeonardosPrimeFactors;

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