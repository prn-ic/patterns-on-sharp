using Decorator;
using Adapter;
using Facade;
using Composite;
using Proxy;
using Bridge;
using Flyweight;

Dictionary<string, Action> actions = new Dictionary<string, Action>()
{
    { "Decorator" , DecoratorExample },
    { "Adapter", AdapterExample },
    { "Facade", FacadeExample },
    { "Composite", CompositeExample },
    { "Proxy", ProxyExample },
    { "Bridge", BridgeExample },
    { "Flyweight", FlyweightExample }
};

PrintResults();

void DecoratorExample()
{
    Browser browser = new AmigoBrowser();
    Console.WriteLine($"Name: {browser.Name}; Extensions: {browser.ExtensionsPath}");
    browser = new AdBlockExtension(browser);
    Console.WriteLine($"Name: {browser.Name}; Extensions: {browser.GetExtensions()}");
    browser = new TranslatorExtension(browser);
    Console.WriteLine($"Name: {browser.Name}; Extensions: {browser.GetExtensions()}");
}

void AdapterExample()
{
    Tv tv = new Tv();
    SomeHdmiCabel hdmi = new SomeHdmiCabel();
    SomeVgaCabel vga = new SomeVgaCabel();

    tv.ShowThroughHdmi(hdmi);
    // tv.ShowThroughHdmi(vga) - будет ошибка
    tv.ShowThroughHdmi(new VgaToHdmiAdapter(vga));
}

void FacadeExample()
{
    PcAdapter pc = new PcAdapter();
    Facade.User user = new Facade.User();
    user.UseComputer(pc);
    user.StopComputer(pc);
}

void CompositeExample()
{
    Component menu = new Menu("Menu");
    Component fileSubMenu = new Menu("File");
    Component editSubMenu = new Menu("Edit");

    Component createFile = new LeafMenuItem("Create file");
    Component openFile = new LeafMenuItem("Open file");
    Component saveFile = new LeafMenuItem("Save file");
    fileSubMenu.Add(createFile);
    fileSubMenu.Add(openFile);
    fileSubMenu.Add(saveFile);

    Component undo = new LeafMenuItem("Undo");
    Component redo = new LeafMenuItem("Redo");
    editSubMenu.Add(undo);
    editSubMenu.Add(redo);

    menu.Add(fileSubMenu);
    menu.Add(editSubMenu);
    menu.Act();
}

void ProxyExample()
{
    UserTempData tempData = new UserTempData();
    tempData.Users.Add(new() { Name = "Tom", Password = "123" });
    tempData.Users.Add(new() { Name = "Sam", Password = "321" });

    IUserSubject userRepo = new UserRepository(tempData);
    IUserSubject userSubject = new UserProxy(tempData);

    Console.WriteLine("By proxy: {0}", userSubject.GetByName("Tom"));
    Console.WriteLine("By repository: {0}", userRepo.GetByName("Tom"));
    Console.WriteLine("Add Person: {0}", userSubject.Add(new() { Name = "Roy", Password = "suck"}));

}

void BridgeExample()
{
    Bridge.Car lada = new LadaCar(new CarburetorEngine());
    lada.Name = "ваз 2107";
    lada.StartEngine();
    lada.SetEngine(new InjectorEngine());
    lada.StartEngine();
}

void FlyweightExample()
{
    CarFactory carFactory = new CarFactory();

    Flyweight.Car bmw = carFactory.Get("bmw");
    bmw.Create("M3");
    bmw.Create("M4");
    bmw.Create("M5");
    bmw.Create("M6");
    bmw.Create("M7");

    Flyweight.Car unsignedCar = carFactory.Get("ayf");
    unsignedCar.Create("value");

    Flyweight.Car mercedes = carFactory.Get("MeRcEdEs");
    mercedes.Create("C1");
    mercedes.Create("C2");
    mercedes.Create("C3");
    mercedes.Create("C4 :/");
    mercedes.Create("C5");
}

void PrintResults()
{
    foreach (var action in actions)
    {
        Console.WriteLine($"\n====={action.Key}=====\n");
        action.Value.Invoke();
    }
}