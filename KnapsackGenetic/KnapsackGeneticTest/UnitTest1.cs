using KnapsackGenetic;
using Xunit;
using Xunit.Sdk;

namespace KnapsackGeneticTest;

public class GeneticAlgorithmTest
{
    [Fact]
    public void TestGenerateItems()
    {
        var items = Item.GenerateItems(5, new SeqGenerator());
        Assert.Equal(5, items.Count);
    }
}