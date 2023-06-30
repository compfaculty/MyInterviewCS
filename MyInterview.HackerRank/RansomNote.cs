namespace MyInterview.Test;

// https://www.hackerrank.com/challenges/ctci-ransom-note/submissions/code/166008891?isFullScreen=true&h_l=interview&playlist_slugs%5B%5D=interview-preparation-kit&playlist_slugs%5B%5D=dictionaries-hashmaps
public class RansomNote
{
    public static bool Run(string[] magazine, string[] note)
    {
        var ret = true;
        var maga = new Dictionary<string, int>();
        var ransomNote = new Dictionary<string, int>();
        foreach (var item in magazine)
        {
            if (maga.ContainsKey(item))
            {
                maga[item] += 1;
            }
            else
            {
                maga[item] = 1;
            }
        }

        foreach (string item in note)
        {
            if (ransomNote.ContainsKey(item))
            {
                ransomNote[item] += 1;
            }
            else
            {
                ransomNote[item] = 1;
            }
        }

        foreach (KeyValuePair<string, int> pair in ransomNote)
        {
            if (!(maga.ContainsKey(pair.Key) && maga[pair.Key] >= pair.Value))
            {
                ret = false;
                break;
            }
        }

        return ret;
    }
}

public class RansomNoteTest
{
    [Theory]
    [InlineData("Give them me grows a money", "Give me a money", true)]
    [InlineData("Ruzzia go fuck youself", "Give me a money", false)]
    [InlineData("", "", true)]
    public void TestRun(string magazine, string note, bool retVal)
    {
        var res = RansomNote.Run(magazine.Split(" "), note.Split(" "));
        Assert.Equal(retVal, res);
    }
}