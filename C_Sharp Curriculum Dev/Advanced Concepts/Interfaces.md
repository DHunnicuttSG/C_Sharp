# C# Interfaces & CRUD Operations: A Guide 🛠️

Welcome to this course on Interfaces and their practical application in defining a consistent contract for CRUD (Create, Read, Update, Delete) operations. Interfaces are a cornerstone of object-oriented design in C#, promoting loose coupling and making your code more modular and testable.

This guide will show you how to use an interface to define a standard for data access, which is a powerful pattern known as the Repository Pattern.

**1. What is a C# Interface?**

An interface is a contract that defines a set of public members (methods, properties, events, or indexers) that a class or struct must implement. It specifies what a class should do, but not how it should do it.

Key Characteristics:

Interfaces cannot be instantiated directly.
* An interface can contain declarations of methods, properties, events, and indexers, but not their implementation.
* A class or struct can implement multiple interfaces.
* All members of an interface are implicitly public and abstract. You cannot specify access modifiers like public or private.
* Interfaces are ideal for defining common functionality across different classes.

**2. Interfaces and CRUD Operations**

CRUD is an acronym for the four basic functions of persistent storage:
* Create: Adding new data.
* Read: Retrieving data.
* Update: Modifying existing data.
* Delete: Removing data.

By using an interface to define CRUD operations, you can create a contract for any class that needs to perform these actions. This means you can easily swap out different implementations (e.g., an in-memory repository for testing, a database repository for production) without changing the code that uses the interface. This is a classic example of polymorphism.

**3. Practical Example: The Repository Pattern**

Let's build a practical example. We'll start with a simple data model for a Product, then define an interface for our data access logic, and finally, create a concrete class that implements it.

Step 1: Define the Data Model

First, we need a simple class to represent our data.

```C#
// Models/Product.cs
namespace CrudExample.Models;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
}
```

Step 2: Define the CRUD Interface

This interface declares the methods required for our CRUD operations. Notice that there are no method bodies—just the signatures.

```C#
// Repositories/IProductRepository.cs
using CrudExample.Models;
using System.Collections.Generic;

namespace CrudExample.Repositories;

public interface IProductRepository
{
    // Create
    void Add(Product product);

    // Read
    Product? GetById(int id);
    IEnumerable<Product> GetAll();

    // Update
    void Update(Product product);

    // Delete
    void Delete(int id);
}
```

Step 3: Implement the InterfaceNow we create a concrete class that implements the IProductRepository interface. This class will provide the actual logic for the CRUD operations. For this example, we'll use an in-memory `List<T>` to simulate a database.

```C#
// Repositories/ProductRepository.cs
using CrudExample.Models;
using System.Collections.Generic;
using System.Linq;

namespace CrudExample.Repositories;

public class ProductRepository : IProductRepository
{
    // This private list simulates a database table.
    private readonly List<Product> _products = new List<Product>();
    private int _nextId = 1;

    public void Add(Product product)
    {
        product.Id = _nextId++;
        _products.Add(product);
        Console.WriteLine($"Created product with ID: {product.Id}");
    }

    public Product? GetById(int id)
    {
        // Use LINQ to find the product by ID.
        return _products.FirstOrDefault(p => p.Id == id);
    }

    public IEnumerable<Product> GetAll()
    {
        return _products;
    }

    public void Update(Product product)
    {
        Product? existingProduct = GetById(product.Id);
        if (existingProduct != null)
        {
            existingProduct.Name = product.Name;
            existingProduct.Price = product.Price;
            Console.WriteLine($"Updated product with ID: {product.Id}");
        }
    }

    public void Delete(int id)
    {
        Product? productToDelete = GetById(id);
        if (productToDelete != null)
        {
            _products.Remove(productToDelete);
            Console.WriteLine($"Deleted product with ID: {id}");
        }
    }
}
```

Step 4: Using the Interface in a Program

Here's how you would use the interface and its implementation in your main program logic. Notice that the Program class only interacts with the IProductRepository interface, not the concrete ProductRepository class directly.

```C#
// Program.cs
using CrudExample.Models;
using CrudExample.Repositories;
using System;

namespace CrudExample;

class Program
{
    static void Main(string[] args)
    {
        // We are programming against the interface, not the concrete class.
        // This is key for flexibility!
        IProductRepository repository = new ProductRepository();

        // CREATE a new product.
        repository.Add(new Product { Name = "Laptop", Price = 999.99m });
        repository.Add(new Product { Name = "Mouse", Price = 25.50m });

        // READ all products.
        Console.WriteLine("\n--- All Products ---");
        foreach (var product in repository.GetAll())
        {
            Console.WriteLine($"ID: {product.Id}, Name: {product.Name}, Price: {product.Price:C}");
        }

        // UPDATE an existing product.
        Product? productToUpdate = repository.GetById(1);
        if (productToUpdate != null)
        {
            productToUpdate.Price = 1099.99m;
            repository.Update(productToUpdate);
        }

        // READ an updated product to verify the change.
        Console.WriteLine("\n--- Updated Product ---");
        Product? updatedProduct = repository.GetById(1);
        if (updatedProduct != null)
        {
            Console.WriteLine($"ID: {updatedProduct.Id}, Name: {updatedProduct.Name}, Price: {updatedProduct.Price:C}");
        }

        // DELETE a product.
        repository.Delete(2);

        // READ all remaining products.
        Console.WriteLine("\n--- Final Products ---");
        foreach (var product in repository.GetAll())
        {
            Console.WriteLine($"ID: {product.Id}, Name: {product.Name}, Price: {product.Price:C}");
        }
    }
}
```


**4. Practical Exercise: Employee Repository**

Now it's your turn! Create a new console application and build a similar CRUD system for a simple Employee class.

Your Task:

Create an Employee class with properties like Id, FirstName, LastName, and Department.
Create an IEmployeeRepository interface that defines methods for all four CRUD operations.
Create a concrete EmployeeRepository class that implements IEmployeeRepository and uses an in-memory `List<Employee>` to store the data.

In your Main method, use your repository to:
* Create a few employees.
* Read all employees and print them to the console.
* Update one employee's department.
* Delete one employee.
* Print the final list of employees to verify your changes.

**5. Course Summary and Next Steps**

You've learned that interfaces are a powerful tool for defining contracts in C#, and you've seen how to use them to implement a robust and flexible Repository Pattern for CRUD operations. This approach makes your code more modular, easier to test, and simpler to maintain.

Next Steps:

* Dependency Injection: Learn how to use a dependency injection container to automatically inject the correct repository implementation at runtime.

* Generics: Create a generic `IRepository<T>` interface that can handle CRUD operations for any data model, not just Product or Employee.

* Real-world Databases: Replace the in-memory `List<T>` with a real database connection using a library like Entity Framework Core.