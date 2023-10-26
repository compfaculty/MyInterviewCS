namespace KnapsackGenetic;

public class SeqGenerator : IItemGenerator
{
    public IEnumerable<Item> Generate(int number)
    {
        for (int i = 0; i < number; i++)
        {
            yield return new Item($"item", i, i);
        }
    }

}