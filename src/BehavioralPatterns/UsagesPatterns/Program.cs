﻿using Strategy;
using Observer;
using Command;
using Iterator;
using TemplateMethod;
using State;
using ChainOfResponsibility;
using Interpreter;
using Mediator;
using Memento;
using Visitor;

Dictionary<string, Action> actions = new Dictionary<string, Action>()
{	
	{ "Strategy" , StrategyExample },
	{ "Observer" , ObserverExample },
	{ "Command" , CommandRealization },
	{ "Template Method" , TemplateMethodExample },
	{ "Iterator" , IteratorRealization },
	{ "State" , StateExample },
	{ "Chain Of Responsibility" , ChainOfResponsibilityExample },
	{ "Interpreter" , InterpreterExample },
	{ "Mediator" , MediatorExample },
	{ "Memento" , MementoExample },
	{ "Visitor", VisitorExample }
};

PrintResults();

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
	Observer.Manager alice = new Observer.Manager(sender);
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

	Numerable<PersonLocal> persons = new Numerable<PersonLocal>(new PersonLocal[] {
		new() { Name = "Alex", LastName = "Pizza", Age = 5 },
		new() { Name = "Walter", LastName = "Black", Age = 55 },
		new() { Name = "Saul", LastName = "Goodman", Age = 12 }
	});
	IIterator<PersonLocal> personIterator = persons.Create();

	while (iterator.MoveNext())
	{
		int val = iterator.Current;
		Console.Write(val + " ");
	}

	Console.WriteLine();

	while (personIterator.MoveNext())
	{
		PersonLocal val = personIterator.Current;
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

void StateExample()
{
	Home home = new Home(new NoHomeState());
	home.Build();
	home.Build();
	home.Broke();
	home.Broke();
	home.Broke();

	home.Build();
	home.Build();
	home.Build();
	home.Build();
}

void ChainOfResponsibilityExample()
{
	OrderSizeService orderServiceAllOfTrue = new OrderSizeService(false, false, true);
	OrderHandler smallOrder = new SmallOrder();
	OrderHandler largeOrder = new LargeOrder();
	OrderHandler extraOrder = new ExtraOrder();

	smallOrder.Successor = largeOrder;
	largeOrder.Successor = extraOrder;

	smallOrder.Handle(orderServiceAllOfTrue);
}

void InterpreterExample()
{
	Context context = new Context();
	context.SetWord(1, "hello");
	context.SetWord(2, "world");
	context.SetWord(2, "bitches");

	IExpression expression = new TerminalExpression(1);
	IExpression expression1 = new TerminalExpression(2);

	IExpression dublicateExpression = new DublicateWordToTheDocumentExpression(expression);
	IExpression setOneExpression = new SetOneWordToTheDocumentExpression(expression);

	IExpression dublicateExpression2 = new DublicateWordToTheDocumentExpression(expression1);
	IExpression mergeExpression = new MergeDocumentsExpression(dublicateExpression, expression1); 

	Console.WriteLine(dublicateExpression.Interpret(context));
	Console.WriteLine(setOneExpression.Interpret(context));
	Console.WriteLine(dublicateExpression.Interpret(context));

	Console.WriteLine(dublicateExpression2.Interpret(context));
	Console.WriteLine(mergeExpression.Interpret(context));
}

void MediatorExample()
{
	BuilderCompanyMediator builderCompany = new BuilderCompanyMediator();

	Colleague builder = new BuilderColleague(builderCompany);
	Colleague architechtor = new ArchitechtorColleague(builderCompany);
	Colleague departament = new DepartamentColleague(builderCompany);

	builderCompany.Builder = builder;
	builderCompany.Architechtor = architechtor;
	builderCompany.Departament = departament;

	departament.Send("Нужно построить многоэтажку");
	architechtor.Send("Архитектура дома готова, сроки указаны");
	builder.Send("Многоэтажка построена, где мои денющки?");
}

void MementoExample()
{
	FileHistory fileHistory = new FileHistory();
	Memento.File file = new Memento.File();
	file.AddText("hello world");
	fileHistory.History.Push(file.SaveFile());

	file.AddText("goodbye world");
	file.RestoreFile(fileHistory.History.Pop());
}

void VisitorExample()
{
	CompanyStructure company = new CompanyStructure();
	company.Add(new Visitor.Manager { Name = "John", TotalWorked = 10});
	company.Add(new Visitor.Manager { Name = "Sam", TotalWorked = 20});
	company.Add(new Visitor.Manager { Name = "Tom", TotalWorked = 30});
	company.Add(new Washer { Name = "Zinaida", TotalRooms = 1, Qualisize = 228});
	company.Accept(new JsonVisitor());
	Console.WriteLine("=======================");
	company.Accept(new HtmlVisitor());
	Console.WriteLine("=======================");
	company.Accept(new TableVisitor());
}

void PrintArray(int[] array)
{
	foreach (var item in array)
	{
		Console.Write(item + " ");
	}
	Console.WriteLine();
}

void PrintResults()
{
	foreach (var action in actions)
	{
		Console.WriteLine($"\n====={action.Key}=====\n");
		action.Value.Invoke();
	}
}

public class PersonLocal
{
	public string? Name { get; set; }
	public string? LastName { get; set; }
	public int Age { get; set; }
	public override string ToString() =>
		$"Name: {Name}\nLastName: {LastName}\nAge: {Age}\n";
}