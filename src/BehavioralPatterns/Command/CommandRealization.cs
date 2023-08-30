namespace Command;

public interface ICommand
{
    public void Execute();
    public void Undo();
}

public class EmptyCommand : ICommand  
{
    public void Execute() { }
    public void Undo() { }
}

public class Car
{
    public void StartEngine() =>
        Console.WriteLine("Двигатель заведен");
    
    public void StopEngine() =>
        Console.WriteLine("Двигатель заглушен");
}

public class CarCommand : ICommand
{
    private Car car;
    public CarCommand(Car car) => this.car = car;
    public void Execute() => car.StartEngine();
    public void Undo() => car.StopEngine();
}

public class Computer 
{
    public void On() => 
        Console.WriteLine("Компьютер включен");
    
    public void Off() =>
        Console.WriteLine("Компьютер выключен");
}

public class ComputerCommand : ICommand 
{
    private Computer computer;
    public ComputerCommand(Computer computer) => this.computer = computer;
    public void Execute() => computer.On();
    public void Undo() => computer.Off();
}

public class Invoker
{
    private ICommand command = new EmptyCommand();
    public void SetCommand(ICommand command) => this.command = command;
    public void Invoke() => command.Execute();
    public void Disinvoke() => command.Undo();
}