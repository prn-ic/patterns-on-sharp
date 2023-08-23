namespace FactoryMethod.Entities;

public class TruckCar : ICar
{
    public string Name { get; private set; }
    public TruckCar(string name) => Name = name;
}