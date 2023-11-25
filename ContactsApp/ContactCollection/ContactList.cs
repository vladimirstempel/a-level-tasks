using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ContactCollection.Enums;
using ContactCollection.Models;
using ContactCollection.Extensions;

namespace ContactCollection;

public sealed class ContactList : IEnumerable<KeyValuePair<string, List<Contact>>>
{
    private readonly Dictionary<string, List<Contact>> _contacts = new();
    private readonly Dictionary<SupportedLanguages, string> _sections = new();

    public ContactList()
    {
        _sections.Add(SupportedLanguages.English, "English");
        _sections.Add(SupportedLanguages.Ukrainian, "Ukrainian");
        _sections.Add(SupportedLanguages.Number, "Number");
        _sections.Add(SupportedLanguages.None, "#");
        
        _contacts.Add(_sections[SupportedLanguages.English], new List<Contact>());
        _contacts.Add(_sections[SupportedLanguages.Ukrainian], new List<Contact>());
        _contacts.Add(_sections[SupportedLanguages.Number], new List<Contact>());
        _contacts.Add(_sections[SupportedLanguages.None], new List<Contact>());
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

    public Contact? SearchByName(string name)
    {
        var firstChar = name.FirstOrDefault();

        return _contacts[GetLanguageByChar(firstChar)].Find(x => x.Name.ToLower().Contains(name.ToLower()));
    }

    private void AddNumberToList(string name, string number, string language)
    {
        if (_contacts.TryGetValue(language, out var contactList))
        {
            contactList.Add(new Contact(name, number));
            _contacts[language] = contactList.OrderByContactName();
        }
    }

    private string GetLanguageByChar(char firstChar)
    {
        
        if (char.IsDigit(firstChar))
        {
            return _sections[SupportedLanguages.Number];
        }

        if (IsUkrainianLetter(firstChar))
        {
            return _sections[SupportedLanguages.Ukrainian];
        }

        if (IsEnglishLetter(firstChar))
        {
            return _sections[SupportedLanguages.English];
        }

        return _sections[SupportedLanguages.None];
    }
    
    private bool IsEnglishLetter(char c)
    {
        // Checking if the character falls within the English alphabet range
        return char.IsLetter(c) && char.GetNumericValue(c) <= 255;
    }

    private bool IsUkrainianLetter(char c)
    {
        // Check if the character is within the Ukrainian alphabet range
        return (c >= 'А' && c <= 'Я') || (c >= 'а' && c <= 'я') || c == 'Ї' || c == 'ї' || c == 'І' || c == 'і' || c == 'Є' || c == 'є';
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