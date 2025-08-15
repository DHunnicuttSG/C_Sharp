```C#
// This example demonstrates I/O-bound concurrency using async and await.
// It simulates fetching data from multiple websites without blocking the main thread.
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("Application started. Main thread is active.");
        Console.WriteLine("--------------------------------------------");

        // Define a list of URLs to download
        List<string> websites = new List<string>
        {
            "https://www.microsoft.com",
            "https://www.google.com",
            "https://www.apple.com",
            "https://www.amazon.com",
        };

        // Create a stopwatch to measure the total time
        var stopwatch = Stopwatch.StartNew();

        // Start the concurrent downloads
        await RunDownloadsConcurrently(websites);
        
        stopwatch.Stop();

        Console.WriteLine("--------------------------------------------");
        Console.WriteLine($"All downloads finished in {stopwatch.ElapsedMilliseconds} ms.");
    }

    /// <summary>
    /// This method performs all downloads concurrently.
    /// It returns a Task that completes when all individual download tasks are done.
    /// </summary>
    /// <param name="urls">A list of URLs to download.</param>
    /// <returns>A Task representing the concurrent downloads.</returns>
    public static async Task RunDownloadsConcurrently(List<string> urls)
    {
        // HttpClient is designed to be instantiated once and reused throughout the life of an application.
        using var client = new HttpClient();
        
        // Create a list to hold all the download tasks
        var downloadTasks = new List<Task>();

        Console.WriteLine("Initiating concurrent downloads...");
        Console.WriteLine("The main thread is NOT blocked while this happens.");

        // Loop through each URL and start a new async download task
        foreach (var url in urls)
        {
            // Start the download and add the returned Task to our list
            downloadTasks.Add(DownloadWebsiteContent(client, url));
        }

        // Wait for all the download tasks to complete.
        // Task.WhenAll is what enables the concurrent execution.
        // It does not block the thread; it simply awaits the completion of all tasks.
        await Task.WhenAll(downloadTasks);
    }
    
    /// <summary>
    /// Downloads content from a given URL asynchronously.
    /// This method is async because it uses await to handle the I/O-bound work.
    /// </summary>
    /// <param name="client">The shared HttpClient instance.</param>
    /// <param name="url">The URL to download.</param>
    /// <returns>A Task that represents the download operation.</returns>
    private static async Task DownloadWebsiteContent(HttpClient client, string url)
    {
        // The await keyword here pauses this method's execution
        // while the I/O operation (the network call) is in progress.
        // The thread is released back to the thread pool to handle other work.
        var content = await client.GetStringAsync(url);
        
        // After the I/O operation is complete, the method resumes here.
        Console.WriteLine($"Downloaded {content.Length} bytes from {url}");
    }
}
```