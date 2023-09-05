namespace Mediator;

public abstract class Mediator 
{
    public abstract void Send(string message, Colleague colleague);
}

public abstract class Colleague
{
    protected Mediator mediator;
    public Colleague(Mediator mediator) => this.mediator = mediator;
    public virtual void Send(string message) => mediator.Send(message, this);
    public abstract void Notify(string message);
}

public class DepartamentColleague : Colleague
{
    public DepartamentColleague(Mediator mediator) : base(mediator) { }
    public override void Notify(string message) =>
        Console.WriteLine("Государству отправлено сообщение: " + message);
}

public class ArchitechtorColleague : Colleague
{
    public ArchitechtorColleague(Mediator mediator) : base(mediator) { }
    public override void Notify(string message) =>
        Console.WriteLine("Архитектору отправлено сообщение: " + message);   
}

public class BuilderColleague : Colleague
{
    public BuilderColleague(Mediator mediator) : base(mediator) { }
    public override void Notify(string message) =>
        Console.WriteLine("Строителю отправлено сообщение: " + message);   
}

public class BuilderCompanyMediator : Mediator 
{
    public Colleague? Builder { get; set; }
    public Colleague? Architechtor { get; set; }
    public Colleague? Departament { get; set; }
    public override void Send(string message, Colleague colleague)
    {
        if (colleague == Departament)
            Architechtor.Notify(message);

        else if (colleague == Architechtor)
            Builder.Notify(message);

        else if (colleague == Builder)
            Departament.Notify(message);
    }
}