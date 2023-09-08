using Decorator;

Dictionary<string, Action> actions = new Dictionary<string, Action>()
{	
	{ "Decorator" , DecoratorExample }
};

PrintResults();

void DecoratorExample()
{
    Browser browser = new AmigoBrowser();
    Console.WriteLine($"Name: {browser.Name}; Extensions: {browser.ExtensionsPath}");
    browser = new AdBlockExtension(browser);
    Console.WriteLine($"Name: {browser.Name}; Extensions: {browser.GetExtensions()}");
    browser = new TranslatorExtension(browser);
    Console.WriteLine($"Name: {browser.Name}; Extensions: {browser.GetExtensions()}");
}

void PrintResults()
{
	foreach (var action in actions)
	{
		Console.WriteLine($"\n====={action.Key}=====\n");
		action.Value.Invoke();
	}
}