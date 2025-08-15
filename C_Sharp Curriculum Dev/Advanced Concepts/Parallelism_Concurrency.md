# C# Course: A Guide to Parallelism and Concurrency

When building modern, high-performance applications, it's essential to use all the computing power available. This module explores parallelism and concurrency, two related but distinct concepts that allow your programs to do more work in the same amount of time. We'll focus on the C# Task Parallel Library (TPL), the primary tool for implementing these patterns.

## 1. Concurrency vs. Parallelism 🧐

It's easy to confuse these two terms, but the distinction is important:

* Concurrency: Deals with managing multiple tasks at once. The tasks may not be running at the exact same time, but the system is making progress on all of them. Think of a waiter taking orders from multiple tables—they are handling the orders concurrently, even if they can only serve one table at a time. Concurrency is about composition of independent tasks.

* Parallelism: Deals with executing multiple tasks at the exact same time. This requires a multi-core processor where each task can be assigned to its own core. Think of a team of chefs, each cooking a different dish simultaneously. Parallelism is about simultaneous execution of independent tasks.

In C#, we achieve concurrency using async/await (for managing I/O-bound tasks) and parallelism using the Task Parallel Library (TPL) (for CPU-bound tasks). This module focuses on parallelism with TPL.

## 2. The Task Parallel Library (TPL) 🚀

The TPL is a set of classes and APIs in the System.Threading.Tasks namespace. It provides a higher-level, more efficient way to perform parallel operations compared to manually creating and managing Thread objects. The TPL automatically manages a pool of threads, so you don't have to.

The main benefits of using TPL are:

* Efficiency: TPL is highly optimized and intelligently manages threads to minimize overhead.

* Simplicity: It provides simple APIs like Parallel.For and Parallel.ForEach, making it easy to parallelize loops.

* Flexibility: It integrates well with other features like Task and async/await.

## 3. Key Parallelism Constructs 🛠️

Parallel.For and Parallel.ForEach

These are the most common entry points into the TPL. They are simple replacements for their synchronous counterparts, designed for parallel execution.

* Parallel.For: A parallel version of the standard for loop. It's used for scenarios where you need to iterate a specific number of times.

* Parallel.ForEach: A parallel version of the foreach loop. It's used to iterate over a collection of items.

The TPL intelligently partitions the work of the loop across multiple threads, allowing the iterations to run in parallel.

## 4. Practical Example: A Performance Comparison ⏱️

Let's use a computationally intensive task to demonstrate the performance benefits of Parallel.For over a standard for loop. We'll simulate a heavy calculation inside the loop.

```C#
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        const int iterations = 10000;
        Console.WriteLine($"Running {iterations} iterations...");
        Console.WriteLine("------------------------------------------");

        // --- Synchronous Execution (Standard for loop) ---
        var stopwatchSync = Stopwatch.StartNew();
        RunSynchronous(iterations);
        stopwatchSync.Stop();
        Console.WriteLine($"Synchronous 'for' loop took: {stopwatchSync.ElapsedMilliseconds} ms");

        Console.WriteLine("------------------------------------------");

        // --- Parallel Execution (Parallel.For) ---
        var stopwatchParallel = Stopwatch.StartNew();
        RunParallel(iterations);
        stopwatchParallel.Stop();
        Console.WriteLine($"Parallel 'for' loop took: {stopwatchParallel.ElapsedMilliseconds} ms");
    }

    // Standard synchronous for loop
    public static void RunSynchronous(int iterations)
    {
        for (int i = 0; i < iterations; i++)
        {
            // Simulate a heavy calculation
            DoHeavyCalculation();
        }
    }

    // Parallel version using Parallel.For
    public static void RunParallel(int iterations)
    {
        Parallel.For(0, iterations, i =>
        {
            // Simulate a heavy calculation
            DoHeavyCalculation();
        });
    }

    // A method to simulate a time-consuming CPU-bound task
    public static void DoHeavyCalculation()
    {
        // Use a simple spin lock to simulate work.
        // Thread.SpinWait is better for CPU-bound tasks than Thread.Sleep.
        Thread.SpinWait(100000); 
    }
}
```

When you run this code, you'll see a significant difference in execution time, with the parallel version completing much faster. The TPL automatically uses multiple cores to execute the loop iterations simultaneously.

## 5. Exercises ✍️

1. Parallel Search: Create a large `List<string>` containing a mix of random words. Write a method that uses Parallel.ForEach to search for all words that contain a specific substring. Measure the performance and compare it to a standard foreach loop.

2. PLINQ: The Parallel LINQ (PLINQ) library is an extension to LINQ that makes it easy to parallelize queries. Take the parallel search from the previous exercise and rewrite it using PLINQ's .AsParallel() extension method.