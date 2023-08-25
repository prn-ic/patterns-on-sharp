namespace Singleton;

public class CarSingleThreaded
{
	private static CarSingleThreaded? instanse;
	public string? CarName { get; private set;}
	protected CarSingleThreaded(string carName) => CarName = carName;
	public static CarSingleThreaded GetInstanse(string carName) 
	{
		if (instanse == null) instanse = new CarSingleThreaded(carName);
		return instanse;
	}
}

public class CarMultiThreaded
{
	private static CarMultiThreaded instanse = new CarMultiThreaded();
	public string? CarName { get; private set;}
	protected CarMultiThreaded() { }
	public static CarMultiThreaded GetInstanse(string carName) 
	{
		instanse.CarName = carName;
		return instanse;
	}
}