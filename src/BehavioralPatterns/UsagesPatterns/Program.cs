using Strategy;
using Observer;
using Command;
using TemplateMethod;

// StrategyExample();
// ObserverExample();
// CommandRealization();
TemplateMethodExample();

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