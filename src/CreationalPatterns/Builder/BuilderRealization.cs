namespace Builder;

public class CarManufacturer
{
	public Car CreateCar(CarBuilder carBuilder)
	{ 
		carBuilder.Create();
		carBuilder.SetWheels();
		carBuilder.SetEngine();
		return carBuilder.Car!;
	}
}

public class LadaCarBuilder: CarBuilder
{
    public override void SetWheels() =>
		Car!.Wheel = new Wheel() { Radius = "14" };
    public override void SetEngine() =>
		Car!.Engine = new Engine() { HorsePower = 1 };
}

public class MercedesCarBuilder: CarBuilder
{
    public override void SetWheels() =>
		Car!.Wheel = new Wheel() { Radius = "123F" };
    public override void SetEngine() =>
		Car!.Engine = new Engine() { HorsePower = 228 };
}

public abstract class CarBuilder
{
	public Car? Car { get; private set; }
	public void Create() => Car = new Car();
	public abstract void SetWheels();
	public abstract void SetEngine();
}
public class Car 
{
	public string Name { get; set; } = "alpha";
	public Car() { }
	public Car(string name) => Name = name;
	public Wheel? Wheel { get; set; }
	public Engine? Engine { get; set; }
}

public class Wheel
{
	public string? Radius { get; set; }
}

public class Engine
{
	public int HorsePower { get; set; }
}