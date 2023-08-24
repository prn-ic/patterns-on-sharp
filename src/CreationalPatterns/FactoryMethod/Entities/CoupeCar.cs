namespace FactoryMethod.Entities;

public class CoupeCar : ICar
{
    public string Name { get; private set; }
    public CoupeCar(string name) => Name = name;
}