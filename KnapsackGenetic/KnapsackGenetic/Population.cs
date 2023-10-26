namespace KnapsackGenetic;

public class Population
{
    private readonly Random _rnd = new();
    private List<Genome> _genomes = new();
    private static IReadOnlyList<Item> _items;
    private static readonly IItemGenerator _generator = new SeqGenerator();
    private readonly int _weightLimit;
    // private readonly Func<Genome,double> _fitnessFunc;

    public Population(int populationSize, int genomeLenght, int weightLimit)
    {
        // _genomes = new Genome[populationSize];
        for (var i = 0; i < populationSize; i++)
        {
            _genomes.Add(new Genome(genomeLenght));
        }

        _items = Item.GenerateItems(genomeLenght, _generator);
        _weightLimit = weightLimit;
    }

    public Genome this[int index] => Genomes[index];

    public List<Genome> Genomes
    {
        get => _genomes;
        set => _genomes = value;
    }

    public IReadOnlyList<Item> Items => _items;

    public double Fitness(Genome genome)
    {
        var weight = 0;
        var price = 0;
        for (var i = 0; i < _items.Count; i++)
        {
            if (genome.Code[i] != 1) continue;
            weight += Items[i].Weight;
            price += Items[i].Price;

            if (weight > _weightLimit) return 0;
        }

        return price;
    }

    //choose pair of parents
    public (Genome, Genome) Selection()
    {
        var weights = Genomes.Select(Fitness).ToList();

        int RandomWeightedIndex(IReadOnlyList<double> w)
        {
            double totalWeight = w.Sum();
            double randomNumber = _rnd.NextDouble() * totalWeight;
            for (var i = 0; i < w.Count; i++)
            {
                if (randomNumber < w[i])
                {
                    return i;
                }

                randomNumber -= w[i];
            }
            return w.Count - 1;
        }

        var parent1 = RandomWeightedIndex(weights);
        var parent2 = RandomWeightedIndex(weights);
        while (parent1 == parent2)
        {
            parent2 = RandomWeightedIndex(weights);
        }

        return (Genomes[parent1], Genomes[parent2]);
    }
}