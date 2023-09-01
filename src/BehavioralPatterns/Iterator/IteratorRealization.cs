using Iterator;

namespace Iterator;

public interface IIterator<T> 
{
    bool MoveNext();
    T? Current { get; set; }
}

public interface INumerator<T>
{   
    T this[int index] { get; }
    IIterator<T> Create();
    int Count { get; }   
}

public class Numerable<T> : INumerator<T>
{
    private T[] vals;
    public Numerable(T[] vals)
    {
        this.vals = vals;
    }
    public int Count { get { return vals.Length; } }  
    public T this[int index] 
    {
         get 
         {
            if (index < 0 && index >= vals.Length)
                throw new ArgumentOutOfRangeException("index");

            return vals[index];
         }
    }   
    public IIterator<T> Create() => new Numerator<T>(this);
}

public class Numerator<T> : IIterator<T>
{
    INumerator<T> aggregate;
    int index = -1;
    public  T? Current { get; set; }
    public Numerator(INumerator<T> iterator)
    {
        aggregate = iterator;
    }
    public bool MoveNext()
    {
        index += 1;

        if (index < aggregate.Count)
        {
            Current = aggregate[index];
            return true;
        }

        return false;
    }

}