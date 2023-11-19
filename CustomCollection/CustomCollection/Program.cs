using Collection;

CustomList<int> list = new ();
CustomList<string> listOfStrings = new ();
List<int> originalList = new ();

Console.WriteLine(list.Count());

list.Add(3);
list.Add(1);
list.Add(4);
list.Add(2);

listOfStrings.Add("b");
listOfStrings.Add("p");
listOfStrings.Add("j");
listOfStrings.Add("a");

foreach (var item in list)
{
    Console.WriteLine("Item from CustomList: {0}", item);
}

list.Sort();

list.SetDefaultAt(3);

Console.WriteLine();

foreach (var item in list)
{
    Console.WriteLine("Sorted item from CustomList: {0}", item);
}

Console.WriteLine("--------------------------------------------------");

foreach (var item in listOfStrings)
{
    Console.WriteLine("String from CustomList: {0}", item);
}

listOfStrings.Sort((a, b) => string.Compare(a, b));

Console.WriteLine();

listOfStrings.SetDefaultAt(3);

foreach (var item in listOfStrings)
{
    Console.WriteLine("Sorted string from CustomList: {0}", item);
}

Console.WriteLine();

// originalList.Add(1);
// originalList.Add(2);
// originalList.Add(3);
//
// foreach (var item in originalList)
// {
//     Console.WriteLine("Item from List: {0}", item);
// }

Console.WriteLine("Exit...");