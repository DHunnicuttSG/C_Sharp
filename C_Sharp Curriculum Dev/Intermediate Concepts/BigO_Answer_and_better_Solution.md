# C# Big O Notation: Finding Duplicates Efficiently 🚀

The FindDuplicate function you provided is a straightforward way to find a duplicate, but its performance is not ideal for large datasets. Let's analyze the original code and then implement a much more efficient solution using a HashSet.

The Original O(n<sup>2</sup>) Solution

Your original code uses two nested loops, which means for every element in the array, you are comparing it to every other element. This results in a quadratic time complexity of O(n2). As your array size (n) doubles, the number of operations quadruples, making it inefficient for large inputs.

```C#
public void FindDuplicate_Inefficient(int[] array)
{
    int n = array.Length;
    for (int i = 0; i < n; i++)
    {
        for (int j = i + 1; j < n; j++)
        {
            if (array[i] == array[j])
            {
                Console.WriteLine($"Found a duplicate: {array[i]}");
            }
        }
    }
}
```

The Efficient O(n) SolutionA more efficient approach is to use a `HashSet<T>`. A HashSet is a collection that stores unique elements and provides a very fast way to check if an element already exists. The Add method of a HashSet has an average time complexity of O(1), meaning it's almost instantaneous, regardless of the size of the set.

By iterating through the array just once and attempting to add each element to a HashSet, we can detect a duplicate instantly when Add returns false. This reduces the complexity from quadratic to linear, O(n).

Efficient C# Code

Here's the refactored code using a HashSet.

```C#
// Program.cs
using System;
using System.Collections.Generic;

namespace BigOAndCollections;

class Program
{
    public static void Main(string[] args)
    {
        int[] numbersWithDuplicates = { 1, 2, 3, 4, 5, 2, 6, 7, 8, 9, 3 };
        FindDuplicate_Efficient(numbersWithDuplicates);
    }

    /// <summary>
    /// Finds and prints duplicate elements in an array using a HashSet.
    /// This is an efficient O(n) solution.
    /// </summary>
    /// <param name="array">The array of integers to check for duplicates.</param>
    public static void FindDuplicate_Efficient(int[] array)
    {
        // We use a HashSet to keep track of elements we've seen.
        var seenNumbers = new HashSet<int>();

        // We iterate through the array only once. This is our O(n) operation.
        foreach (int number in array)
        {
            // The .Add() method of a HashSet returns false if the element already exists.
            // This check is a constant time operation, O(1).
            if (!seenNumbers.Add(number))
            {
                Console.WriteLine($"Found a duplicate: {number}");
            }
        }
    }
}
```

Why this is more efficient:

* Single Loop: The new code uses a single foreach loop, which runs only n times.

* Constant Time Lookup: The seenNumbers.Add(number) operation has an average time complexity of O(1).

The total runtime is dominated by the single loop, giving us an overall time complexity of O(n). This is a significant improvement over the original O(n<sup>2</sup>) solution, especially for large arrays.