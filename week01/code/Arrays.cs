
using System;
using System.Collections.Generic;

public static class Arrays
{
    /// <summary>
    /// This function creates an array of multiples of a number.
    /// </summary>
    /// <returns>An array of doubles that are multiples of the supplied number.</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // Plan:
        // 1. Create a new double array with the given length.
        // 2. Use a loop to go through each position in the array.
        // 3. Multiply the starting number by the position plus one.
        // 4. Store the result in the current position.
        // 5. Return the completed array.

        double[] result = new double[length];

        for (int i = 0; i < length; i++)
        {
            result[i] = number * (i + 1);
        }

        return result;
    }

    /// <summary>
    /// Rotates the list to the right by the given amount.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // Plan:
        // 1. Find the number of items in the list.
        // 2. Find the index where the last 'amount' items begin.
        // 3. Copy those last items into a temporary list.
        // 4. Remove those items from the original list.
        // 5. Insert the temporary list at the beginning.
        // 6. The original list is now rotated to the right.

        int startIndex = data.Count - amount;

        List<int> lastItems = data.GetRange(startIndex, amount);

        data.RemoveRange(startIndex, amount);

        data.InsertRange(0, lastItems);
    }
}
