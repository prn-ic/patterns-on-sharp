namespace Flyweight;

public abstract class Car 
{
    protected int HorsePower = 0;
    protected string DriveUnit = "не назначено";
    protected string CarCategory = "не назначено";
    public abstract void Create(string pseudonym);
}

public class BmwCar : Car
{
    public BmwCar()
    {
        HorsePower = 200;
        DriveUnit = "FWD";
        CarCategory = "B";
    }
    public override void Create(string pseudonym) =>
        Console.WriteLine("[BMW] Выпущена новая модель ({0}), категория прав: {1}, привод: {2} ",
            pseudonym,
            CarCategory,
            DriveUnit);
}

public class MercedesCar : Car
{
    public MercedesCar()
    {
        HorsePower = 250;
        DriveUnit = "RWD";
        CarCategory = "B";
    }
    public override void Create(string pseudonym) =>
        Console.WriteLine("[Mercedes] Выпущена новая модель ({0}), категория прав: {1}, привод: {2} ",
            pseudonym,
            CarCategory,
            DriveUnit);
}

public class EmptyCar : Car
{
    public override void Create(string pseudonym) =>
        Console.WriteLine("[None] машина не была найдена");
}

public class CarFactory
{
    Dictionary<string, Car> carDictionary = new Dictionary<string, Car>()
    {
        { "empty", new EmptyCar() },
        { "bmw", new BmwCar() },
        { "mercedes", new MercedesCar() },
    };

    public Car Get(string key)
    {
        Car car = carDictionary["empty"];
        if (carDictionary.ContainsKey(key.ToLower()))
            car = carDictionary[key.ToLower()];

        return car;
    }
}