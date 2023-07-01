namespace MyInterview.Test.RansomNote;

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