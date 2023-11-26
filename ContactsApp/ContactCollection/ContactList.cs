using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ContactCollection.Enums;
using ContactCollection.Models;

namespace ContactCollection;

public sealed class ContactList : IEnumerable<KeyValuePair<string, List<Contact>>>
{
    private readonly Dictionary<string, List<Contact>> _contacts = new();

    public ContactList()
    {
        _contacts.Add(GetSection(SupportedLanguages.English), new List<Contact>());
        _contacts.Add(GetSection(SupportedLanguages.Ukrainian), new List<Contact>());
        _contacts.Add(GetSection(SupportedLanguages.Number), new List<Contact>());
        _contacts.Add(GetSection(SupportedLanguages.None), new List<Contact>());
    }

    public int Count()
    {
        int count = 0;
        foreach (var keyValue in _contacts)
        {
            count += keyValue.Value.Count;
        }

        return count;
    }

    public void Add(string name, string number)
    {
        var firstChar = name.FirstOrDefault();

        AddNumberToList(name, number, GetLanguageByChar(firstChar));
    }

    public Contact SearchByName(string name)
    {
        var firstChar = name.FirstOrDefault();

        return _contacts[GetLanguageByChar(firstChar)].Find(x => x.Name.ToLower().Contains(name.ToLower()));
    }

    private void AddNumberToList(string name, string number, string language)
    {
        if (_contacts.TryGetValue(language, out var contactList))
        {
            contactList.Add(new Contact(name, number));
            _contacts[language] = contactList.OrderBy(c => c.Name).ToList();
        }
    }

    private string GetLanguageByChar(char firstChar)
    {
        if (char.IsDigit(firstChar))
        {
            return GetSection(SupportedLanguages.Number);
        }

        if (IsUkrainianLetter(firstChar))
        {
            return GetSection(SupportedLanguages.Ukrainian);
        }

        if (IsEnglishLetter(firstChar))
        {
            return GetSection(SupportedLanguages.English);
        }

        return GetSection(SupportedLanguages.None);
    }

    private bool IsEnglishLetter(char c)
    {
        // Checking if the character falls within the English alphabet range
        return char.IsLetter(c) && char.GetNumericValue(c) <= 255;
    }

    private bool IsUkrainianLetter(char c)
    {
        // Check if the character is within the Ukrainian alphabet range
        return (c >= 'А' && c <= 'Я') || (c >= 'а' && c <= 'я') || c == 'Ї' || c == 'ї' || c == 'І' || c == 'і' ||
               c == 'Є' || c == 'є';
    }

    private string GetSection(SupportedLanguages lang)
    {
        switch (lang)
        {
            case SupportedLanguages.English:
                return "English";
            case SupportedLanguages.Ukrainian:
                return "Ukrainian";
            case SupportedLanguages.Number:
                return "Number";
            default:
                return "#";
        }
    }

    public IEnumerator<KeyValuePair<string, List<Contact>>> GetEnumerator()
    {
        return _contacts.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}