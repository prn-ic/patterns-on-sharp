namespace AbstractFactory;

public interface IMovement
{
	public void Move();
}

public interface IAction
{
	public void Act();
}

public interface IPersonFactory
{
	public IMovement CreateMovement();
	public IAction CreateAction();
}

public class Walk : IMovement
{
	public void Move() => Console.WriteLine("Walking");
}

public class Run : IMovement
{
	public void Move() => Console.WriteLine("Running");
}

public class Take : IAction
{
	public void Act() => Console.WriteLine("Taking");
}

public class Drop : IAction
{
	public void Act() => Console.WriteLine("Drop");
}

public class Policeman : IPersonFactory
{
	public IMovement CreateMovement() => new Walk();
	public IAction CreateAction() => new Take();
}

public class Thief : IPersonFactory
{
	public IMovement CreateMovement() => new Run();
	public IAction CreateAction() => new Drop();
}

public class Person
{
	private IPersonFactory factory;
	public Person(IPersonFactory factory) => this.factory = factory;
	public void Move() => factory.CreateMovement().Move();
	public void Act() => factory.CreateAction().Act();
}

