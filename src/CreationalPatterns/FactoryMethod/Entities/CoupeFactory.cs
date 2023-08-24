namespace FactoryMethod.Entities;

public class CoupeFactory : CarFactory
{
    public CoupeFactory(string name): base(name) { }
    public override ICar Create(string name)
    {
        return new CoupeCar(name);
    }
}