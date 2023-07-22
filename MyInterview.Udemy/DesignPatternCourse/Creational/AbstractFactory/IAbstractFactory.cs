namespace MyIntervew.Udemy.DesignPatternCourse.Creational.AbstractFactory;

public interface IAbstractFactory
{
    IAbstractProductA CreateProductA();

    IAbstractProductB CreateProductB();
}