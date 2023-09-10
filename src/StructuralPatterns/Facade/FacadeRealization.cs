namespace Facade;

public class Bios
{
    public void CheckParams() =>
        Console.WriteLine("[✓](0) Проверка BIOS (check sum)");
}

public class TestHardware
{
    public void CheckRam() =>
        Console.WriteLine("[✓] Проверяем ОЗУ");
    public void CheckBaseElements() =>
        Console.WriteLine("[✓] Проверяем прочие элементы");
}

public class Initializer
{
    public void InitializeRam() =>
        Console.WriteLine("[✓] Инициализируем ОЗУ");
    public void InitializeBaseElements() =>
        Console.WriteLine("[✓] Инициализируем прочие элементы");
    public void InitializeAnyElements() =>
        Console.WriteLine("[✓] Инициализируем перифирию");
}

public class TurnOn
{
    public void TurnOnVideocard() =>
        Console.WriteLine("[✓] Включаем видеокарту");

    public void TurnOnPicture() =>
        Console.WriteLine("[✓] Выводим картинку на экран");

    public void TurnOnSystem() =>
        Console.WriteLine("[✓] Передаем управление системе, 'включаем' систему");
}

public class PcAdapter
{
    private Bios bios = new Bios();
    private TestHardware testHardware = new TestHardware();
    private Initializer initializer = new Initializer();
    private Facade.TurnOn turnOn = new Facade.TurnOn();
    public void TurnOn()
    {
        bios.CheckParams();
        initializer.InitializeRam();
        initializer.InitializeBaseElements();
        testHardware.CheckRam();
        testHardware.CheckBaseElements();
        turnOn.TurnOnVideocard();
        turnOn.TurnOnPicture();
        initializer.InitializeAnyElements();
        turnOn.TurnOnSystem();
    }
    public void TurnOff() =>
        Console.WriteLine("[x] Выключение");
}

public class User
{
    public void UseComputer(PcAdapter pc)
    {
        pc.TurnOn();
    }
    public void StopComputer(PcAdapter pc)
    {
        pc.TurnOff();
    }
}