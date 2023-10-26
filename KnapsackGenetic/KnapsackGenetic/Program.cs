// See https://aka.ms/new-console-template for more information

using System.Diagnostics;
using KnapsackGenetic;

Evolution.Run(28, 3000, 10000, 50);

internal static class Evolution
{
    public static void Run(int genomeLenght, int weightLimit, int generationsLimit, int populationSize)
    {
        for (int i = 2; i < genomeLenght; i++)
        {
            var watch = Stopwatch.StartNew();
            var targetValue = Enumerable.Range(1, i).Sum();

            var population = RunEvolution(i, weightLimit, generationsLimit, targetValue, out var gens);
            watch.Stop();
            var percent = population.Fitness(population[0]) / targetValue * 100;
            Console.WriteLine(
                $"{i}\t|\t{gens}\t|\t{watch.ElapsedMilliseconds}\t|\t{percent:F1}%\t|\t{population[0]}");
        }

        
    }

    static Population RunEvolution(int genomeLenght, int weightLimit, int generationsLimit, int targetValue,
        out int gens)
    {
        var population = new Population(10, genomeLenght, weightLimit);
        gens = 0;
        for (var ii = 0; ii < generationsLimit; ii++)
        {
            population.Genomes = population.Genomes.OrderByDescending(g => population.Fitness(g)).ToList();

            // population.Genomes = orderedPopulation;

            if (population.Fitness(population.Genomes[0]) >= targetValue) break;

            List<Genome> nextGeneration = new() { population[0], population[1] };

            for (var j = 0; j < population.Genomes.Count / 2 - 1; j++)
            {
                var (parent1, parent2) = population.Selection();
                var (offspring1, offspring2) = parent1.SinglePointCrossover(parent2);
                offspring1.Mutate();
                offspring2.Mutate();
                nextGeneration.Add(offspring1);
                nextGeneration.Add(offspring2);
            }

            // Console.WriteLine($"NEXT {nextGeneration.Count}");
            // Console.WriteLine($"POP {population.Genomes.Count}");
            population.Genomes = nextGeneration;
            gens++;
        }

        return population;
    }
}