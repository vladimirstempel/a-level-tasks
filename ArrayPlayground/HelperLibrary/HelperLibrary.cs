using System;

namespace UtilityLibraries;

public static class HelperLibrary
{
    public static void FillArrayWithRandomInt(this int[] array, int min, int max)
    {   
        for (var i = 0; i < array.Length; i++)
        {
            array[i] = new Random().Next(min, max);
        }
    }
}