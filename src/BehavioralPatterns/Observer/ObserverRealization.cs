namespace Observer;

public interface IObserver
{
	void Update(object obj);
}

public interface IObservable
{
	void AddObserver(IObserver observer);
	void RemoveObserver(IObserver observer);
	void Notify();
}

public class EmailSender : IObservable
{
	string? SomeInfo = "Some info";
	List<IObserver> observers = new List<IObserver>();
	public void AddObserver(IObserver observer) => observers.Add(observer);
	public void RemoveObserver(IObserver observer) => observers.Remove(observer);
	public void Notify()
	{
		foreach (IObserver observer in observers)
			observer.Update(SomeInfo);
	}
	public void SendNewMessage(string message)
	{
		SomeInfo = message;
		Notify();
	}
}

public class Manager : IObserver
{
	public string? Name { get; set; }
	public IObservable? observable;
	public Manager(IObservable observable)
	{
		this.observable = observable;
		observable.AddObserver(this);
	}
	public void Update(object obj)
	{
		Console.WriteLine($"Менеджер {Name} получил новое сообщение!\n Сообщение: {(string)obj}");
	}
}

public class User : IObserver
{
	public string? Name { get; set; }
	public IObservable? observable;
	public User(IObservable observable)
	{
		this.observable = observable;
		observable.AddObserver(this);
	}
	public void Update(object obj)
	{
		Console.WriteLine($"Пользователь {Name} получил новое сообщение!\n Сообщение: {(string)obj}");
	}
	public void RefuseSending() 
	{
		observable.RemoveObserver(this);
		observable = null;
	}
}
