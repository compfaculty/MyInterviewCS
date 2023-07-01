namespace MyInterview.Test.InsertionSort;

public class InsertionSort
{
    public static int[] Run(int[] array)
    {
        var length = array.Length;
        for (var i = 1; i < length; i++)
        {
            var key = array[i];
            var flag = 0;
            for (var j = i - 1; j >= 0 && flag != 1;)
                if (key < array[j])
                {
                    array[j + 1] = array[j];
                    array[--j + 1] = key;
                }
                else
                {
                    flag = 1;
                }
        }

        return array;
    }
}