using System.Collections;
using System.Collections.Generic;

namespace Collection;

public class CustomList<T> : IEnumerator<T>
{
    private const int DefaultSize = 2;

    private T[] _items;

    private int _cursor = -1;

    public T Current
    {
        get
        {
            try
            {
                return _items[_cursor];
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e);
                throw new InvalidOperationException();
            }
        }
    }

    object IEnumerator.Current => Current;
    
    public T? this[int index]
    {
        get
        {
            if (index >= _items.Length)
            {
                throw new IndexOutOfRangeException();
            }
            return _items[index];
        }
        set
        {
            if (_items.Length < index)
            {
                _items[index] = value;
            }
        }
    }

    public CustomList()
    {
        _items = new T[DefaultSize];
    }

    public int Count()
    {
        int count = 0;
        foreach (var item in _items)
        {
            if (item != null && item is not 0)
            {
                count++;
            }
        }

        return count;
    }

    public void Add(T item)
    {
        if (Count() < DefaultSize)
        {
            _items[Count()] = item;
            return;
        }

        var newIndex = _items.Length;

        Array.Resize(ref _items, newIndex + 1);

        _items[newIndex] = item;
    }

    public void Sort()
    {
        Array.Sort(_items);
    }

    public void Sort(Comparison<T> callback)
    {
        Array.Sort(_items, callback);
    }

    public void SetDefaultAt(int index)
    {
        if (index >= _items.Length)
        {
            throw new IndexOutOfRangeException();
        }

        _items[index] = default(T);
    }

    public IEnumerator<T> GetEnumerator()
    {
        return this;
    }

    public bool MoveNext()
    {
        _cursor++;
        return _cursor < Count();
    }

    public void Reset()
    {
        _cursor = -1;
    }

    public void Dispose()
    {
        Reset();
    }
}