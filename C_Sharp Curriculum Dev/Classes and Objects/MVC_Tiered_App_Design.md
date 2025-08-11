# C# MVC & Tiered Application Design: A Course Guide 🏛️

This course guide will introduce you to two essential software design patterns for building robust and scalable C# applications: tiered application design and the Model-View-Controller (MVC) pattern. By separating your application into distinct layers and components, you'll create a codebase that is easier to maintain, test, and expand.

**1. Understanding Tiered Application Design**

Tiered application design, also known as n-tier architecture, is a pattern where an application is divided into logical and physical layers. Each layer has a specific responsibility and communicates with a limited number of other layers.

Imagine a restaurant:

* The Customer is the Presentation Layer. They interact with the menu and the waiter, but don't care how the food is made.

* The Waiter is the Business Logic Layer. They take orders, communicate with the kitchen, and bring the food out. They manage the flow of the process.

* The Kitchen is the Data Access Layer. They retrieve ingredients, cook the food, and handle all the raw materials.

Separating your application this way helps to:

* Decouple Concerns: Changes in the data storage (e.g., switching from a file to a database) don't require changes to the user interface.

* Improve Scalability: You can scale each layer independently.

* Increase Testability: You can easily write unit tests for each layer in isolation.

The most common tiers are:

1. Presentation Layer: The user interface (UI). It displays information to the user and handles their input. This is where the MVC pattern typically lives.

2. Business Logic Layer: Contains the core business rules and logic of the application. It orchestrates tasks and validates data.

3. Data Access Layer: Handles all communication with the data source (e.g., a database, an external API, or a file system). It is responsible for CRUD (Create, Read, Update, Delete) operations.

**2. The Model-View-Controller (MVC) Pattern**

MVC is a popular architectural pattern that separates an application's user interface into three interconnected components: the Model, the View, and the Controller. It is a perfect fit for the Presentation Layer of a tiered application.

* Model: The data and the business logic that manipulate that data. It's the "what" of your application. The Model notifies the View of any changes to its state.

* View: The user interface. It is responsible for presenting the data from the Model to the user. It can be a web page, a console window, or a desktop form. The View does not contain any business logic.

* Controller: The traffic cop. It receives user input (e.g., a button click or a web request), processes it, updates the Model, and tells the View what to display. It orchestrates the flow.

The typical flow of a request in an MVC application looks like this:

1. The user interacts with the View.

2. The interaction is sent to the Controller.

3. The Controller processes the input and updates the Model.

4. The Model updates its data.

5. The Controller selects the correct View to display the updated data.

6. The View renders the data and presents it to the user.

**3. Integrating MVC with Tiered Design**

This is where the two concepts come together. In a well-designed tiered application, the MVC pattern exists primarily within the Presentation Layer. The Controller does not directly talk to the database. Instead, it uses a Business Logic Layer to perform actions, which in turn uses a Data Access Layer to interact with the data source.

* Presentation Layer (MVC):

    * Controller: Calls methods on the Business Logic Layer.
    
    * View: Displays data returned from the Business Logic Layer.
    
    * Model: The simple data transfer object (DTO) that passes data between the tiers.
    
    * Business Logic Layer: Contains classes that perform the actual work (e.g., UserService, ProductService).
    
    * Data Access Layer: Contains classes that handle data retrieval (e.g., UserRepository, ProductRepository).
    
**4. Practical Exercises: A Tiered Application with MVC**

Let's build a simple console application to demonstrate this design. We'll simulate a web application's structure.

Exercise 1: Project Setup

1. In Visual Studio, create a new empty solution.

2. Add a new project to the solution and select "Class Library". Name it Data. This will be our Data Access Layer.

3. Add another new "Class Library" project to the solution. Name it Services. This will be our Business Logic Layer.

4. Add a new "Console App" project. Name it WebApp. This will be our Presentation Layer (simulating an ASP.NET Core web app).

5. In the WebApp project, add a project reference to the Services project.

6. In the Services project, add a project reference to the Data project.

Your solution should have a clear, one-way dependency flow: WebApp -> Services -> Data.

Exercise 2: The Data Access Layer (Data Project)

In your Data project, create the following files to define our model and a simple in-memory repository.

`Product.cs`

```C#
// Data/Product.cs
namespace Data;

// This is our Model - a simple C# class to represent a product.
public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
}
```IProductRepository.cs`
```csharp
// Data/IProductRepository.cs
using System.Collections.Generic;

namespace Data;

// The interface defines the contract for data access.
public interface IProductRepository
{
    IEnumerable<Product> GetAllProducts();
    Product GetProductById(int id);
}
```InMemoryProductRepository.cs`
```csharp
// Data/InMemoryProductRepository.cs
using System.Collections.Generic;
using System.Linq;

namespace Data;

// This is our repository implementation for the Data Access Layer.
// It stores data in memory instead of a database.
public class InMemoryProductRepository : IProductRepository
{
    private readonly List<Product> _products;

    public InMemoryProductRepository()
    {
        _products = new List<Product>
        {
            new Product { Id = 1, Name = "Laptop", Price = 1200.00m },
            new Product { Id = 2, Name = "Mouse", Price = 25.50m },
            new Product { Id = 3, Name = "Keyboard", Price = 75.00m }
        };
    }

    public IEnumerable<Product> GetAllProducts()
    {
        return _products;
    }

    public Product GetProductById(int id)
    {
        return _products.FirstOrDefault(p => p.Id == id);
    }
}
```

Exercise 3: The Business Logic Layer (Services Project)

In your Services project, create the following files.

`ProductService.cs`

```C#
// Services/ProductService.cs
using Data; // Reference to the Data project

namespace Services;

// This is our service class for the Business Logic Layer.
// It contains business rules and talks to the repository.
public class ProductService
{
    private readonly IProductRepository _productRepository;

    // The constructor takes an interface to the repository,
    // which makes this class independent of the specific repository implementation.
    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    // A business method that retrieves all products.
    // It could add validation or other logic here if needed.
    public IEnumerable<Product> GetAllProducts()
    {
        return _productRepository.GetAllProducts();
    }

    // A business method that retrieves a single product.
    public Product GetProductById(int id)
    {
        return _productRepository.GetProductById(id);
    }
}
```

Exercise 4: The Presentation Layer (WebApp Project)

In your WebApp project, we will use a console app to simulate the MVC flow. We'll create a "Controller" and then a Main method that acts as the entry point, orchestrating the request.

`ProductController.cs`

```C#
// WebApp/ProductController.cs
using System;
using Services; // Reference to the Services project
using Data; // Reference to the Data project

namespace WebApp;

// Our Controller for the MVC pattern in the Presentation Layer.
// It receives input and coordinates with the service.
public class ProductController
{
    private readonly ProductService _productService;

    // We get the service through the constructor.
    public ProductController(ProductService productService)
    {
        _productService = productService;
    }

    // This method simulates an action for a web request to get all products.
    public void ListAllProducts()
    {
        Console.WriteLine("Controller received a request to list all products.");

        // The Controller calls a method on the Business Logic Layer.
        var products = _productService.GetAllProducts();
        
        // This simulates a View rendering the data.
        RenderProductsView(products);
    }

    // A simulated View for displaying products.
    private void RenderProductsView(IEnumerable<Product> products)
    {
        Console.WriteLine("\n--- Rendering the Products View ---");
        foreach (var product in products)
        {
            Console.WriteLine($"ID: {product.Id}, Name: {product.Name}, Price: {product.Price:C}");
        }
        Console.WriteLine("---------------------------------");
    }
}
```

`Program.cs`

```csharp
// WebApp/Program.cs
using System;
using Data;
using Services;
using WebApp;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Application Started.");

        // --- TIERED APPLICATION SETUP ---
        // 1. Create a Data Access Layer instance.
        IProductRepository repository = new InMemoryProductRepository();

        // 2. Create a Business Logic Layer instance, passing the repository.
        ProductService service = new ProductService(repository);

        // 3. Create a Presentation Layer (Controller) instance, passing the service.
        ProductController controller = new ProductController(service);

        // --- SIMULATE USER INTERACTION (MVC Flow) ---
        // A "user" triggers a request. The Controller handles it.
        controller.ListAllProducts();

        Console.WriteLine("\nApplication Finished.");
        Console.ReadKey();
    }
}
```

**5. Course Summary and Next Steps**

You've successfully built a basic tiered application and implemented the MVC pattern within the Presentation Layer. You've seen how the WebApp (Presentation) depends on the Services (Business Logic), which in turn depends on the Data (Data Access), without direct communication between the top and bottom layers.

Next Steps:

* Dependency Injection: Manually creating instances like new InMemoryProductRepository() is not scalable. Learn how to use a Dependency Injection container to manage these dependencies automatically.

* Real Database: Replace InMemoryProductRepository with a class that uses a real database connection (e.g., with Entity Framework Core).

* Actual MVC: Replace the Console app with an actual ASP.NET Core MVC project and Razor Views to build a real web application.