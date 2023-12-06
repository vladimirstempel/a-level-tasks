using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ExtensionMethods;

public static class ExtensionMethods
{
    public static T FirstOrDefault<T>(this IEnumerable<T> source, T defaultValue = default)
    {
        var enumerable = source.ToList();
        return enumerable.Count() > 0 ? enumerable[0] : defaultValue;
    }

    public static ICollection<T> Where<T>(this ICollection<T> source, Func<T, bool> callback)
    {
        Collection<T> collection = new Collection<T>(); // Default Collection Type

        foreach (var item in source)
        {
            if (callback(item))
            {
                collection.Add(item);
            }
        }

        return collection;
    }

    public static ICollection<TR> Select<T, TR>(this IEnumerable<T> source, Func<T, TR> callback)
    {
        Collection<TR> collection = new Collection<TR>(); // Default Collection Type

        foreach (var item in source)
        {
            var result = callback(item);
            collection.Add(result);
        }

        return collection;
    }

    public static int Count<T>(this IEnumerable<T> source)
    {
        var count = 0;

        foreach (var item in source)
        {
            if (item != null)
            {
                count++;
            }
        }

        return count;
    }

    public static T ElementAt<T>(this IEnumerable<T> source, Index index)
    {
        T element = default;
        bool breaked = false;
        
        using IEnumerator<T> enumerator = source.GetEnumerator();
        var cursor = 0;
        
        while (enumerator.MoveNext() && !breaked)
        {
            if (cursor.Equals(index.Value))
            {
                element = enumerator.Current;
                breaked = true;
                enumerator.Reset();
                enumerator.Dispose();
            }
            cursor++;
        }

        return element;
    }

    public static List<T> ToList<T>(this IEnumerable<T> source)
    {
        var list = new List<T>();
        for (var i = 0; i < source.Count(); i++)
        {
            if (source.ElementAt(i) != null)
            {
                list.Add(source.ElementAt(i));
            }
        }

        return list;
    }

    public static T[] ToArray<T>(this IEnumerable<T> source)
    {
        var array = new T[source.Count()];
        var cursor = 0;
        
        for (var i = 0; i < source.Count(); i++)
        {
            if (source.ElementAt(i) != null)
            {
                array[cursor] = source.ElementAt(i);
                cursor++;
            }
        }
    
        return array;
    }
}