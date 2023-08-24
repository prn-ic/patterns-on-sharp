namespace FactoryMethod.Entities;

public class TruckFactory : CarFactory
{
    public TruckFactory(string name): base(name) { }
    public override ICar Create(string name)
    {
        return new TruckCar(name);
    }
}