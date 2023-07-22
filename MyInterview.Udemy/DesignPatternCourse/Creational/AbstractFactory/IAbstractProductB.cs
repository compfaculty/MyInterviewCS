namespace MyIntervew.Udemy.DesignPatternCourse.Creational.AbstractFactory;

// Each distinct product of a product family should have a base interface.
// All variants of the product must implement this interface.
// Here's the the base interface of another product. All products can
// interact with each other, but proper interaction is possible only between
// products of the same concrete variant.
public interface IAbstractProductB
{
    // Product B is able to do its own thing...
    string UsefulFunctionB();

    // ...but it also can collaborate with the ProductA.
    //
    // The Abstract Factory makes sure that all products it creates are of
    // the same variant and thus, compatible.
    string AnotherUsefulFunctionB(IAbstractProductA collaborator);
}