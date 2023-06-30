namespace MyInterview.Test;

// https://www.hackerrank.com/challenges/two-strings/problem?isFullScreen=true&h_l=interview&playlist_slugs%5B%5D=interview-preparation-kit&playlist_slugs%5B%5D=dictionaries-hashmaps
public class TwoStrings
{
    public static bool Run(string? s1, string? s2)
    {
        if (s1 != null && s2 != null)
        {
            var hashSet1 = new HashSet<char>(s1.ToCharArray());
            var hashSet2 = new HashSet<char>(s2.ToCharArray());
            return hashSet1.Overlaps(hashSet2);
        }

        return false;
    }
}

public class TwoStringsTest
{
    [Theory]
    [InlineData("asd", "azx", true)]
    [InlineData("sd", "zx", false)]
    [InlineData("", "", false)]
    [InlineData("", "1234", false)]
    public void TestRun(string s1, string s2, bool retVal)
    {
        var res = TwoStrings.Run(s1, s2);
        Assert.Equal(retVal, res);
    }
}