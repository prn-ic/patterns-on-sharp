namespace State;

public interface IHomeState
{
    void Build(Home home);
    void Broke(Home home);
}

public class Home
{
    public IHomeState State { get; set; }
    public Home(IHomeState state) => State = state;
    public void Build() => State.Build(this);
    public void Broke() => State.Broke(this);
}

public class NoHomeState : IHomeState
{
    public void Build(Home home)
    {
        Console.WriteLine("Начинается создание дома");
        home.State = new BuildFundamentState();
    }
    public void Broke(Home home) => Console.WriteLine("Нечего разбирать");
}

public class BuildFundamentState : IHomeState
{
    public void Build(Home home) 
    {
        Console.WriteLine("Фундамент заложен и начинаем делать стены");
        home.State = new BuildWallState();
    }
    public void Broke(Home home) 
    {
        Console.WriteLine("Разобран фундамент");
        home.State = new NoHomeState();
    }
}

public class BuildWallState : IHomeState
{
    public void Build(Home home) 
    {
        Console.WriteLine("Стены возведены, начинаем делать крышу");
        home.State = new BuildRoofState();
    }
    public void Broke(Home home)
    {
        home.State = new BuildFundamentState();
        Console.WriteLine("Разрушены стены");
    }
}

public class BuildRoofState : IHomeState
{
    public void Build(Home home) => Console.WriteLine("Крыша поставлена!");
    public void Broke(Home home)
    {
        Console.WriteLine("Крыша разрушена");
        home.State = new BuildWallState();
    }
}



