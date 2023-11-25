using ContactCollection.Models;

namespace ContactCollection.Extensions;

public static class CollectionExtensions
{
    public static List<Contact> OrderByContactName(this List<Contact> list)
    {
        var cyrillicOrderedList = list.Where(l => !string.IsNullOrEmpty(l.Name) && IsCyrillic(l.Name[0]))
            .OrderBy(l => l.Name);
        var latinOrderedList = list.Where(l => string.IsNullOrEmpty(l.Name) || !IsCyrillic(l.Name[0]))
            .OrderBy(l => l.Name);
        return cyrillicOrderedList.Concat(latinOrderedList).ToList();
    }

    //cyrillic symbols start with code 1024 and end with 1273.
    private static bool IsCyrillic(char ch) =>
        ch >= 1024 && ch <= 1273;       
}