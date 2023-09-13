namespace Bridge;

public interface IEngine 
{
    public string? FuelType { get; set; }
    public void StartEngine();
}

public class CarburetorEngine : IEngine
{
    public string FuelType { get; set; } = "92";
    public void StartEngine()
    {
        Console.WriteLine("Впуск. Клапана открыты");
        Console.WriteLine("Сжатие. Клапана прикрыты. Поршень сжимает жидкость");
        Console.WriteLine("Расширение. Свеча зажигание приводит жидкость в возгорание");
        Console.WriteLine("Впрыск");
    }
}

public class InjectorEngine : IEngine
{
    public string FuelType { get; set; } = "95";
    public void StartEngine()
    {
        Console.WriteLine("Впуск. Бензонанос подкачивает топливо");
        Console.WriteLine("Поджигаем смесь.");
    }
}

public abstract class Car
{
    public string Name { get; set; } = "untitled car";
    public string Number { get; set; } = "0xxx00123";
    protected IEngine engine;
    public Car(IEngine engine) =>
        this.engine = engine;
    public virtual void StartEngine() 
    {
        Console.WriteLine("Начинаем заводить {0}", Name);
        engine.StartEngine();
    }
    public virtual void SetEngine(IEngine engine) =>
        this.engine = engine;
}

public class LadaCar : Car 
{
    public LadaCar(IEngine engine) : base(engine) { }
    public override void SetEngine(IEngine engine) 
    {
        Console.WriteLine("[Lada] Установлен новый двигатель!");
        this.engine = engine;
    }
}

public class ScodaCar : Car 
{
    public ScodaCar(IEngine engine) : base(engine) { }
    public override void SetEngine(IEngine engine) 
    {
        Console.WriteLine("[Scoda] Установлен новый двигатель!");
        this.engine = engine;
    }
}
