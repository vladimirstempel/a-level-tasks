namespace HomeWork4;

using UtilityLibraries;

public static class ArrayService
{
    private const int DefaultRandomMin = 1;
    private const int DefaultRandomMax = 26;

    private static readonly char[] Alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
    private static readonly List<char> CharsToUppercase = new() { 'a', 'e', 'i', 'd', 'h', 'j' };


    public static int[] GetRandomIntArray(int min = DefaultRandomMin, int max = DefaultRandomMax)
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

        array.FillArrayWithRandomInt(min, max);

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

    public static int CountUppercaseFromArray(char[] array)
    {
        return array.Count(char.IsUpper);
    }
}