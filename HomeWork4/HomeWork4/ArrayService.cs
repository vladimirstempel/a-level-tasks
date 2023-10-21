namespace HomeWork4;

using UtilityLibraries;

public static class ArrayService
{
    private static readonly char[] Alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
    private static readonly List<char> CharsToUppercase = new() { 'a', 'e', 'i', 'd', 'h', 'j' };

    public static int[] GetRandomIntArray()
    {
        int arrayLength;

        do
        {
            Console.WriteLine("Please specify array length (integers only).");

            int.TryParse(Console.ReadLine(), out arrayLength);

            if (arrayLength == 0)
            {
                Console.Clear();
                Console.WriteLine("Please use integers only!");
            }
        } while (arrayLength == 0);

        var array = new int[arrayLength];

        array.FillArrayWithRandomInt(1, 26);

        return array;
    }

    public static int[] GetEvenIntArray(int[] array)
    {
        return array.Where(number => (number % 2) == 0).ToArray();
    }

    public static int[] GetOddIntArray(int[] array)
    {
        return array.Where(number => (number % 2) != 0).ToArray();
    }

    public static char[] GetCharsFromNumbers(int[] array)
    {
        char[] result = array.Select(number =>
        {
            if (CharsToUppercase.Contains(Alphabet[number]))
            {
                return char.ToUpper(Alphabet[number]);
            }

            return Alphabet[number];
        }).ToArray();

        return result;
    }
}