namespace MyInterview.Test.SherlockTasks;

// https://www.hackerrank.com/challenges/sherlock-and-anagrams/problem?isFullScreen=true&h_l=interview&playlist_slugs%5B%5D=interview-preparation-kit&playlist_slugs%5B%5D=dictionaries-hashmaps
public class SherlockAndAnagrams
{
    public static int Run(string s)
    {
        var words = new Dictionary<string, int>();
        for (var i = 0; i < s.Length; i++)
        for (var j = 0; j < s.Length - i; j++)
        {
            var sub = new string(s.Substring(j, i + 1).ToCharArray().OrderBy(ch => ch).ToArray());
            if (!words.ContainsKey(sub))
                words.Add(sub, 1);
            else
                words[sub] += 1;
        }

        var ret = 0;
        foreach (var val in words) ret += val.Value * (val.Value - 1) / 2;

        return ret;
    }
}