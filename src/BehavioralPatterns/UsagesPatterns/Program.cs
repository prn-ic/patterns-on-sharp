using Strategy;
using Observer;
using Command;
using Iterator;
using TemplateMethod;

// StrategyExample();
// ObserverExample();
// CommandRealization();
// TemplateMethodExample();
IteratorRealization();

void StrategyExample()
{
	int[] array = new int[] { 5, 3, 2, 7, 4, 1 };

	Console.WriteLine("=BubbleSort=");
	Console.WriteLine("Array after: ");
	PrintArray(array);

	Sort sort = new Sort();
	sort.SortAlghoritm = new BubbleSort();

	sort.SortArray(array);
	Console.WriteLine("Array before: ");
	PrintArray(array);

	array = new int[] { 5, 3, 2, 7, 4, 1 };
	Console.WriteLine("=LinearSort=");
	Console.WriteLine("Array after: ");
	PrintArray(array);

	sort.SortAlghoritm = new LinearSort();

	sort.SortArray(array);
	Console.WriteLine("Array before: ");
	PrintArray(array);
}

void ObserverExample()
{
	EmailSender sender = new EmailSender();
	Manager alice = new Manager(sender);
	alice.Name = "Алиса";
	User ivan = new User(sender);
	ivan.Name = "Иван";

	sender.SendNewMessage("hello bitches! buy my new course!!!");

	ivan.RefuseSending();

	sender.SendNewMessage("I`m real Mr.Beast!!! We give you 1 million dollars!!");
}

void CommandRealization()
{
    Car car = new Car();
    Invoker invoker = new Invoker();
	invoker.SetCommand(new CarCommand(car));	
    invoker.Invoke();
    invoker.Disinvoke();

    Computer computer = new Computer();
    invoker.SetCommand(new ComputerCommand(computer));
    invoker.Invoke();
    invoker.Disinvoke();

}

void IteratorRealization()
{
	Numerable<int> numerables = new Numerable<int>(new[] { 1, 2, 3, 4, 5});
	IIterator<int> iterator = numerables.Create();

	Numerable<Person> persons = new Numerable<Person>(new Person[] {
		new() { Name = "Alex", LastName = "Pizza", Age = 5 },
		new() { Name = "Walter", LastName = "Black", Age = 55 },
		new() { Name = "Saul", LastName = "Goodman", Age = 12 }
	});
	IIterator<Person> personIterator = persons.Create();

	while (iterator.MoveNext())
	{
		int val = iterator.Current;
		Console.Write(val + " ");
	}

	Console.WriteLine();

	while (personIterator.MoveNext())
	{
		Person val = personIterator.Current;
		Console.WriteLine(val + "==================");
	}

	Console.WriteLine();
}

void TemplateMethodExample()
{
	Person person = new Person();
	Animal animal = new Animal();
	Ghost ghost = new Ghost();

	Console.WriteLine("Person realization:");
	person.LifeCycle();
	
	Console.WriteLine("Animal realization:");
	animal.LifeCycle();

	Console.WriteLine("Ghost realization:");
	ghost.LifeCycle();
}

void PrintArray(int[] array)
{
	foreach (var item in array)
	{
		Console.Write(item + " ");
	}
	Console.WriteLine();
}

public class Person
{
	public string? Name { get; set; }
	public string? LastName { get; set; }
	public int Age { get; set; }
	public override string ToString() =>
		$"Name: {Name}\nLastName: {LastName}\nAge: {Age}\n";
}