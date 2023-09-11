namespace Composite;

public abstract class Component 
{
    protected string Name { get; set; } = "untitled";
    public Component() { }
    public Component(string name) => Name = name;
    public virtual void Add(Component component) { }
    public virtual void Remove(Component component) { }
    public virtual void Act() =>
        Console.WriteLine("- {0}", Name);
}

public class Menu : Component
{
    List<Component> components = new List<Component>();
    public Menu(string name) : base(name) { }
    public override void Add(Component component) =>
        components.Add(component);
    public override void Remove(Component component) =>
        components.Remove(component);
    public override void Act() 
    {
        Console.WriteLine("== {0} ==", Name);
        foreach (Component component in components)
        {
            Console.Write("  ");
            component.Act();
        }

    }
}

public class LeafMenuItem : Component
{
    public LeafMenuItem(string name) : base(name) { }
    public override void Act()
    {
        Console.Write("   ");
        base.Act();
    }
}