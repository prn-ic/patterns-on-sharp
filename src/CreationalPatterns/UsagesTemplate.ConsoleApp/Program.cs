using FactoryMethod.Entities;
using AbstractFactory;

// FactoryMethodExample();
AbstractFactoryExample();
void FactoryMethodExample()
{
    CarFactory factory = new TruckFactory("ZIL"); 
    ICar truckCar = factory.Create("130"); // Create a truck with name "130"
    PrintForCarCreated(factory, truckCar);

    factory = new CoupeFactory("Some Car Factory"); // upcast
    ICar coupeCar = factory.Create("new coupe car"); // Create a coupe with name "new coupe car"
    PrintForCarCreated(factory, truckCar);
}

void AbstractFactoryExample()
{
    Person policeman = new Person(new Policeman());
    Person thief = new Person(new Thief());
    policeman.Move();
    thief.Move();
    policeman.Act();
    thief.Act();
}

void PrintForCarCreated(CarFactory factory, ICar car)
{
    Console.WriteLine($"{factory.FactoryName} release a new {car.GetType().Name} -> {car.Name}");
}