using FactoryMethod.Entities;

FactoryMethodExample();

void FactoryMethodExample()
{
    CarFactory factory = new TruckFactory("ZIL"); 
    ICar truckCar = factory.Create("130"); // Create a truck with name "130"
    PrintForCarCreated(factory, truckCar);

    factory = new CoupeFactory("Some Car Factory"); // upcast
    ICar coupeCar = factory.Create("new coupe car"); // Create a coupe with name "new coupe car"
    PrintForCarCreated(factory, truckCar);
}

void PrintForCarCreated(CarFactory factory, ICar car)
{
    Console.WriteLine($"{factory.FactoryName} release a new {car.GetType().Name} -> {car.Name}");
}