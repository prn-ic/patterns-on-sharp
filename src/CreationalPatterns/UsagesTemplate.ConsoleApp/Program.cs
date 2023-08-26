using FactoryMethod.Entities;
using AbstractFactory;
using Singleton;
using Prototype;

// FactoryMethodExample();
// AbstractFactoryExample();
// SingletonExample();
PrototypeExample();

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

void SingletonExample()
{
    CarSingleThreaded firstCar = CarSingleThreaded.GetInstanse("MAZDA");
    CarSingleThreaded secondCar = CarSingleThreaded.GetInstanse("AUDI");
    
    Console.WriteLine(firstCar.CarName);
    Console.WriteLine(secondCar.CarName);
}

void PrototypeExample()
{
    IFile txtFile = new TxtFile("txtFile");
    txtFile.Content = "123";
    IFile txtCopyFile = txtFile.Clone();
    Console.WriteLine($"|\t name \t | \t content \t |\n" +
        $" {txtFile.Name} \t \t {txtFile.Content} \t\n" + 
        $" {txtCopyFile.Name} \t \t {txtCopyFile.Content} \t\n");
}

void PrintForCarCreated(CarFactory factory, ICar car)
{
    Console.WriteLine($"{factory.FactoryName} release a new {car.GetType().Name} -> {car.Name}");
}