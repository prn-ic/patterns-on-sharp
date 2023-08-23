namespace FactoryMethod.Entities;

public abstract class CarFactory
{
    public string FactoryName { get; } = "Unnamed factory";
    public int FactoryRate { get; private set;}
    public CarFactory(string factoryName, int factoryRate)
    {
        FactoryName = factoryName;
        FactoryRate = factoryRate;
    }
    public CarFactory(string factoryName) => FactoryName = factoryName;
    public void UpRate() => FactoryRate += 1;
    public void DownRate() => FactoryRate -= 1;
    abstract public ICar Create(string carName);
}