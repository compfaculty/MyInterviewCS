namespace MyIntervew.Udemy.DesignPatternCourse.Creational.Builder;

public class BuilderTest
{
    static void MainTest()
    {
        // The client code creates a builder object, passes it to the
        // director and then initiates the construction process. The end
        // result is retrieved from the builder object.
        var builder = new Builder();
        var director = new Director(builder);
        // director.Builder = builder;

        Console.WriteLine("Standard basic product:");
        director.BuildMinimalViableProduct();
        Console.WriteLine(builder.GetProduct().ListParts());

        Console.WriteLine("Standard full featured product:");
        director.BuildFullFeaturedProduct();
        Console.WriteLine(builder.GetProduct().ListParts());

        // Remember, the Builder pattern can be used without a Director
        // class.
        Console.WriteLine("Custom product:");
        builder.BuildPartA();
        builder.BuildPartC();
        Console.Write(builder.GetProduct().ListParts());
    }
}