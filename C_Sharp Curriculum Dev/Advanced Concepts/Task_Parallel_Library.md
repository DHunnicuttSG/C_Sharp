# C# Course: The Task Parallel Library (TPL)

The Task Parallel Library (TPL) is a powerful set of APIs in C# that makes it simple to write multi-threaded and parallel code. It's designed to help you execute CPU-intensive tasks simultaneously across multiple processor cores, significantly improving the performance of your applications.

Instead of manually creating and managing Thread objects, which can be complex and error-prone, the TPL provides a higher-level, more efficient approach. It intelligently manages a pool of worker threads for you, allowing you to focus on the business logic of your parallel operations.

## 1. Key TPL Concepts 🚀

The TPL is primarily used for parallelism, which is the simultaneous execution of multiple tasks on separate processor cores. This is distinct from concurrency, which is about managing multiple tasks but not necessarily running them all at the same time. The TPL is your go-to tool for CPU-bound work, like heavy calculations, data processing, or complex algorithms.

The main benefits of using TPL are:

Automatic Thread Management: The TPL handles the creation and management of threads from a thread pool, minimizing overhead.

Simplified APIs: It provides easy-to-use methods for parallelizing loops and other operations.

Scalability: Your application can automatically scale to take advantage of the number of cores available on the user's machine.

## 2. Core Parallel Constructs 🛠️

The TPL provides several key classes and methods for running code in parallel. The most common are:

`Parallel.For`

This method is a parallel version of the standard for loop. It's ideal for scenarios where you need to iterate a specific number of times and each iteration is independent of the others.

```C#
// The loop iterations can run on multiple threads
Parallel.For(0, 100, i =>
{
    // Perform a calculation for each iteration
    Console.WriteLine($"Running on index: {i}");
});
```
`Parallel.ForEach`

This is the parallel equivalent of the foreach loop. It's used to iterate over a collection (like a `List<T>` or array) and execute an action for each element.

```C#
var numbers = new `List<int>` { 1, 2, 3, 4, 5 };

// The processing of each number can happen in parallel
Parallel.ForEach(numbers, number =>
{
    Console.WriteLine($"Processing number: {number}");
});
```

`Parallel.Invoke`

This method allows you to execute a set of independent actions in parallel. It's useful when you have a few distinct tasks that can run at the same time.

```C#
Parallel.Invoke(
    () => Console.WriteLine("Action 1 is running."),
    () => Console.WriteLine("Action 2 is running."),
    () => Console.WriteLine("Action 3 is running.")
);
```

## 3. Practical Example: Performance Comparison ⏱️

To see the TPL in action, let's compare the performance of a standard for loop with a Parallel.For loop when performing a computationally intensive task.

```C#
using System;
using System.Diagnostics;
using System.Threading.Tasks;

class Program
{
    // A method to simulate a time-consuming CPU-bound task
    private static void DoHeavyCalculation()
    {
        // This simulates a lot of work without I/O
        double result = 0;
        for (int i = 0; i < 10000; i++)
        {
            result += Math.Sqrt(i) * Math.Sin(i);
        }
    }

    static void Main(string[] args)
    {
        const int iterations = 5000;
        Console.WriteLine($"Running {iterations} heavy calculations...");
        Console.WriteLine("------------------------------------------");

        // --- Synchronous Execution (Standard for loop) ---
        var stopwatchSync = Stopwatch.StartNew();
        for (int i = 0; i < iterations; i++)
        {
            DoHeavyCalculation();
        }
        stopwatchSync.Stop();
        Console.WriteLine($"Synchronous 'for' loop took: {stopwatchSync.ElapsedMilliseconds} ms");

        Console.WriteLine("------------------------------------------");

        // --- Parallel Execution (Parallel.For) ---
        var stopwatchParallel = Stopwatch.StartNew();
        Parallel.For(0, iterations, i =>
        {
            DoHeavyCalculation();
        });
        stopwatchParallel.Stop();
        Console.WriteLine($"Parallel 'for' loop took: {stopwatchParallel.ElapsedMilliseconds} ms");
    }
}
```

When you run this code, the output will show that the Parallel.For loop completes in a fraction of the time, demonstrating the power of parallel execution on a multi-core machine.

## 4. Exercises ✍️

1. Parallel Data Processing: Create a `List<int>` containing 10,000 random integers. Write a console application that uses Parallel.ForEach to iterate through the list. In each iteration, simulate a long-running operation by taking the square root of the number and storing the result in a new, thread-safe `ConcurrentBag<double>`. Measure and compare the performance with a standard foreach loop.

2. PLINQ: The Parallel LINQ (PLINQ) library is a powerful extension that makes it easy to parallelize LINQ queries. Take the parallel data processing exercise above and rewrite it using PLINQ's .AsParallel() extension method on your list. Verify that the performance is similar to your Parallel.ForEach implementation.