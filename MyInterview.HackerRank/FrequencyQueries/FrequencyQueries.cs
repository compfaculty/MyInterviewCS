namespace MyInterview.Test.FrequencyQueries;

// https://www.hackerrank.com/challenges/frequency-queries/problem?isFullScreen=true&h_l=interview&playlist_slugs%5B%5D=interview-preparation-kit&playlist_slugs%5B%5D=dictionaries-hashmaps
public class FrequencyQueries
{
    public static List<int> Run(List<List<int>> queries)
    {
        var data = new Dictionary<int, int>();
        var ret = new List<int>();
        foreach (var q in queries)
        {
            switch (q[0], q[1])
            {
                case (1, var x1):
                    if (data.ContainsKey(x1))
                    {
                        data[x1]++;
                    }
                    else
                    {
                        data[x1] = 1;
                    }

                    break;
                case (2, var x2):
                    if (data.ContainsKey(x2) && data[x2] > 0)
                    {
                        data[x2]--;
                    }

                    break;
                case (3, var x3):
                    ret.Add(data.ContainsValue(x3) ? 1 : 0);
                    break;
            }
        }

        return ret;
    }
}