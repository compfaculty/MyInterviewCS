namespace KnapsackGenetic;

public interface IItemGenerator
{
    IEnumerable<Item> Generate(int number);
}