namespace ChainOfResponsibility;

public class OrderSizeService 
{
    public bool IsSmall { get; set; }
    public bool IsLarge { get; set; }
    public bool IsExtra { get; set; }
    public OrderSizeService(bool isSmall, bool isLarge, bool isExtra)
    {
        IsSmall = isSmall;
        IsLarge = isLarge;
        IsExtra = isExtra;
    }
}

public abstract class OrderHandler
{
    public abstract void Handle(OrderSizeService service);
    public OrderHandler? Successor { get; set; }
}

public class SmallOrder : OrderHandler
{
    public override void Handle(OrderSizeService service) 
    {
        if (service.IsSmall) Console.WriteLine("Заказ меньше всех! Вы уверены?");
        else if (Successor is not null)
        {
            Console.WriteLine("Такой размер вам не подошел(S), посмотрим побольше");
            Successor.Handle(service);
        }
    }
}

public class LargeOrder : OrderHandler 
{
    public override void Handle(OrderSizeService service)
    {
        if (service.IsLarge) Console.WriteLine("Заказ средний. Вы уверены?");
        else if (Successor is not null)
        {
            Console.WriteLine("Такой размер вам не подошел(L), посмотрим побольше");
            Successor.Handle(service);
        }
    }
}

public class ExtraOrder : OrderHandler
{
    public override void Handle(OrderSizeService service)
    {
        if (service.IsExtra) Console.WriteLine("Заказ огромен! Вы уверены?");
        else if (Successor is not null)
        {
            Console.WriteLine("Такой размер вам не подошел(X), посмотрим побольше");
            Successor.Handle(service);
        }
    }
}
