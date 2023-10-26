namespace KnapsackGenetic;

public class Genome
{
    private readonly int[] _code;
    private static readonly double _mutationProbability = 0.5;
    private static readonly Random _rnd = new();

    public Genome(int lenght)
    {
        _code = new int[lenght];
        for (var i = 0; i < lenght; i++)
        {
            _code[i] = _rnd.Next(0, 2); //fill with 0 - 1
        }
    }

    public Genome(int[] data)
    {
        _code = data;
    }

    public (Genome, Genome) SinglePointCrossover(Genome other)
    {
        if (_code.Length != other._code.Length)
            throw new ArgumentException("genomes lenght should be the same");

        if (_code.Length < 2)
            return (this, other);

        var point = _rnd.Next(1, _code.Length - 1);

        var arr1 = _code[..point].Concat(other._code[point..]).ToArray();
        var arr2 = other._code[..point].Concat(_code[point..]).ToArray();

        return (new Genome(arr1), new Genome(arr2));
    }

    public int[] Code => _code;

    public void Mutate()
    {
        var index = _rnd.Next(Code.Length);
        Code[index] = _rnd.NextDouble() > _mutationProbability ? Code[index] : Math.Abs(Code[index] - 1);
    }

    public IReadOnlyList<Item> GetItems(IReadOnlyList<Item> items)
    {
        return items.Where((t, i) => Code[i] == 1).ToList();
    }
    
    public void PrintItems(IReadOnlyList<Item> items)
    {
        foreach (var item in items)
        {
            Console.WriteLine(item);
        }
    }


    public override string ToString()
    {
        return string.Join(".", Code);
    }
}