namespace MyInterview.Test.TwoStrings;

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