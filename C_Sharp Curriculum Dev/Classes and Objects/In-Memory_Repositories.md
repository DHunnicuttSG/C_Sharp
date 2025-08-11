# C# In-Memory Repositories: A Course Guide 💾

This course guide will teach you about in-memory repositories in C#. An in-memory repository is a design pattern used to simulate a database for development, testing, or applications that don't require persistent storage. It's a great way to decouple your application logic from your data storage mechanism.

**1. What is an In-Memory Repository?**

An in-memory repository is a class that mimics the behavior of a database by storing data in a temporary data structure, such as a List or a Dictionary, within the application's memory. This data is non-persistent, meaning it is lost when the application stops running.

Key Characteristics:

* Non-Persistent Data: Data only exists as long as the application is running.
* Simple to Implement: No database connections, schemas, or complex configurations are needed.
* Fast: Operations are lightning-fast because they are performed directly in RAM, without the overhead of disk I/O or network calls.
* Ideal for Testing: Perfect for unit and integration testing where you need to quickly set up and tear down a data store.

**2. Setting Up the Project**

For this course, we'll build a simple console application to manage a list of Product objects.

Exercise 1: Create a Console Application and the Model Class

1. Open Visual Studio and create a new "Console App" project.
2. In your project, create a new file named Product.cs. This will be our model class.
3. Add the following code to Product.cs:namespace InMemoryRepositoryApp;

```C#
public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
}
```

**3. The Repository Pattern**

The repository pattern provides an abstraction layer between the application's business logic and the data access logic. It defines a set of methods for accessing data (e.g., Add, GetById, GetAll, Update, Delete) without exposing the underlying storage implementation.

Exercise 2: Create the Repository Interface

1. Create a new file named IProductRepository.cs.
2. Add the following code to define the repository interface. This interface will define the contract for all repository implementations, including our in-memory version.

```C#
using System.Collections.Generic;

namespace InMemoryRepositoryApp;

public interface IProductRepository
{
    void Add(Product product);
    Product GetById(int id);
    IEnumerable<Product> GetAll();
    void Update(Product product);
    void Delete(int id);
}
```

**4. Building the In-Memory Repository**

Now, let's create the concrete implementation of our repository interface. We'll use a private List`<Product>`to store the data.

Exercise 3: Implement the In-Memory Repository Class
1. Create a new file named InMemoryProductRepository.cs.
2. Add the following code. Pay close attention to the use of a List for storage and a simple counter for generating unique IDs.

```C#
using System.Collections.Generic;
using System.Linq;

namespace InMemoryRepositoryApp;

public class InMemoryProductRepository : IProductRepository
{
    // A simple in-memory list to simulate a database table.
    private readonly List<Product> _products = new();
    private int _nextId = 1;

    public void Add(Product product)
    {
        product.Id = _nextId++;
        _products.Add(product);
    }

    public Product GetById(int id)
    {
        return _products.FirstOrDefault(p => p.Id == id);
    }

    public IEnumerable<Product> GetAll()
    {
        return _products.AsReadOnly();
    }

    public void Update(Product product)
    {
        var existingProduct = GetById(product.Id);
        if (existingProduct != null)
        {
            existingProduct.Name = product.Name;
            existingProduct.Price = product.Price;
        }
    }

    public void Delete(int id)
    {
        var productToRemove = GetById(id);
        if (productToRemove != null)
        {
            _products.Remove(productToRemove);
        }
    }
}
```

**5. Putting It All Together**

Finally, let's use our repository in the main application logic to demonstrate the CRUD (Create, Read, Update, Delete) operations.

Exercise 4: Use the Repository in Program.cs

1. Open your Program.cs file.
2. Replace the default code with the following. This code will create an instance of our in-memory repository and perform various operations on it.

```C#
using System;
using System.Linq;

namespace InMemoryRepositoryApp;

class Program
{
    static void Main(string[] args)
    {
        // Create an instance of our in-memory repository.
        IProductRepository productRepository = new InMemoryProductRepository();
        Console.WriteLine("In-memory repository initialized.");

        // --- CREATE (Add) ---
        Console.WriteLine("\n--- Adding Products ---");
        productRepository.Add(new Product { Name = "Laptop", Price = 1200.00m });
        productRepository.Add(new Product { Name = "Mouse", Price = 25.50m });
        productRepository.Add(new Product { Name = "Keyboard", Price = 75.00m });

        // --- READ (GetAll) ---
        Console.WriteLine("\n--- All Products ---");
        var allProducts = productRepository.GetAll();
        PrintProducts(allProducts);

        // --- READ (GetById) ---
        Console.WriteLine("\n--- Get Product by ID 2 ---");
        var product2 = productRepository.GetById(2);
        Console.WriteLine($"Found: ID {product2.Id}, Name: {product2.Name}, Price: {product2.Price:C}");

        // --- UPDATE ---
        Console.WriteLine("\n--- Updating Product with ID 1 ---");
        var product1 = productRepository.GetById(1);
        if (product1 != null)
        {
            product1.Price = 1150.00m; // A new, lower price!
            productRepository.Update(product1);
            Console.WriteLine($"Updated product: ID {product1.Id}, Name: {product1.Name}, New Price: {product1.Price:C}");
        }

        // --- DELETE ---
        Console.WriteLine("\n--- Deleting Product with ID 3 ---");
        productRepository.Delete(3);

        // --- READ (Verify changes) ---
        Console.WriteLine("\n--- All Products after Update and Delete ---");
        var remainingProducts = productRepository.GetAll();
        PrintProducts(remainingProducts);

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }

    // Helper method to print product details
    public static void PrintProducts(IEnumerable<Product> products)
    {
        if (products == null || !products.Any())
        {
            Console.WriteLine("No products found.");
            return;
        }

        foreach (var product in products)
        {
            Console.WriteLine($"ID: {product.Id}, Name: {product.Name}, Price: {product.Price:C}");
        }
    }
}
```

**6. Course Summary and Next Steps**

This guide has walked you through the process of building a C# application using the in-memory repository pattern. You've learned how to define an interface, create a simple implementation using a List, and integrate it into your main application logic.

Possible Extensions:

* Testing: Write unit tests for the InMemoryProductRepository to ensure all CRUD methods work as expected.

* Dependency Injection: Use a Dependency Injection container (like the one built into .NET) to inject the IProductRepository into your application logic. This makes it easy to swap out the in-memory version for a real database implementation later.

* Real Database Integration: Create a new class, SqlProductRepository for instance, that implements IProductRepository but uses a real database (like SQL Server or SQLite) for data storage.

* Concurrency: Modify the InMemoryProductRepository to be thread-safe for use in multi-threaded applications.