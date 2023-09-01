namespace TemplateMethod;

public abstract class Unit 
{
    public void LifeCycle()
    {
        Born();
        Survival();
        Heirs();
        Die();
    }
    public abstract void Born();
    public abstract void Survival();
    public abstract void Heirs();
    public abstract void Die();
}

public class Person : Unit
{
    public override void Born() => 
        Console.WriteLine("Рождение в родильном доме");

    public override void Die() =>
        Console.WriteLine("Умер и захоронен на кладбище");

    public override void Heirs() =>
        Console.WriteLine("Нашел жену и продолжил род");

    public override void Survival() =>
        Console.WriteLine("Закончил школу, отработал 20 лет");
}

public class Animal : Unit
{
    public override void Born() =>
        Console.WriteLine("Рождение на природе");

    public override void Die() =>
        Console.WriteLine("Мертв и заброшен");

    public override void Heirs() =>
        Console.WriteLine("Сношал всех самок");

    public override void Survival() =>
        Console.WriteLine("Добыча пищи, защита рода");
}

public class Ghost : Unit
{
    public new void LifeCycle()
    {
        Born();
        Survival();
    }
    public override void Born() =>
        Console.WriteLine("Неизвестное появление");

    public override void Die() { }

    public override void Heirs() { }

    public override void Survival() =>
        Console.WriteLine("Добыча за пустыми телами");
}