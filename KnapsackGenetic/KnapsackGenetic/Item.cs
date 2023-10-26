namespace KnapsackGenetic;

public class Item
{
    public Item(string name, int price, int weight)
    {
        Name = name;
        Price = price;
        Weight = weight;
    }

    public int Weight { get; }

    public int Price { get; }

    public string Name { get; }

    public static List<Item> GenerateItems(int amount, IItemGenerator generator)
    {
        return generator.Generate(amount).ToList();
    }

    public override string ToString()
    {
        return $"{Name}--{Price}--{Weight}";
    }
}