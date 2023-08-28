namespace Strategy;

public interface ISortAlghoritm
{
	public void Sort(int[] array);
}

public class BubbleSort : ISortAlghoritm
{
	public void Sort(int[] array) 
	{
		for (int i = 0; i < array.Length; i++)
		{
			for (int j = i; j < array.Length; j++)
			{
				if (array[j] < array[i])
				{
					int temp = array[i];
					array[i] = array[j];
					array[j] = temp;
				}
			}
		}
	}
}

public class LinearSort : ISortAlghoritm
{
	public void Sort(int[] array)
	{
		for (int i = 0; i < array.Length - 1; i++)
        {
            int maxIndex = i;
 
            for (int j = i + 1; j < array.Length; j++)
            {
                if (array[j] < array[maxIndex])
                {
                    maxIndex = j;
                }
            }
            int temp = array[maxIndex];
            array[maxIndex] = array[i];
            array[i] = temp;
        }
	}
}

public class Sort
{
	public ISortAlghoritm SortAlghoritm { private get; set; }
	public void SortArray(int[] array)
	{
		SortAlghoritm.Sort(array);
	}

}
