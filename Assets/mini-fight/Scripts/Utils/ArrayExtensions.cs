using UnityEngine;

public static class ArrayExtensions
{
    public static T GetRandomElement<T>(this T[] array)
    {
        return array[Random.Range(0, array.Length)];
    }
}