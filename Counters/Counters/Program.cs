using System;
using System.Threading;

class Program
{
    // The shared resource that multiple threads will access
    private static int _sharedCounter = 0;

    static void Main(string[] args)
    {
        Console.WriteLine("Main thread started.");

        // Create two new threads, each running the IncrementCounter method
        Thread thread1 = new Thread(IncrementCounter);
        Thread thread2 = new Thread(IncrementCounter);
        Thread thread3 = new Thread(IncrementCounter);
        Thread thread4 = new Thread(IncrementCounter);

        // Start the threads
        thread1.Start();
        thread2.Start();
        thread3.Start();
        thread4.Start();

        // The Main thread waits for both worker threads to finish
        thread1.Join();
        thread2.Join();
        thread3.Join();
        thread4.Join();

        Console.WriteLine("All worker threads have finished.");
        Console.WriteLine($"Final counter value (without locking): {_sharedCounter}");
        // This value is likely to be less than 4000 due to race conditions.
    }

    public static void IncrementCounter()
    {
        for (int i = 0; i < 1000; i++)
        {
            _sharedCounter++;
        }
        Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} finished incrementing.");
    }
}
