# C# Course: Introduction to Mocking and Unit Testing

Mocking is a powerful technique used in unit testing to isolate a unit of code (like a class or a method) from its external dependencies. By replacing real dependencies with "mock" objects, you can test your code in a controlled and predictable environment, without worrying about external factors like database connections, API calls, or file systems.

## 1. What is Mocking? 🧪

In a unit test, you want to test one specific thing in isolation. However, most classes don't exist in a vacuum; they depend on other classes to do their work. Mocking allows you to create simulated objects that mimic the behavior of a real dependency.

Imagine you have a UserService that needs to fetch user data from a DatabaseRepository. When you unit test the UserService, you don't want to actually connect to a database. You just want to ensure that the UserService calls the correct method on the DatabaseRepository and handles the data correctly.

A mock object for the DatabaseRepository would allow you to:

* Control the output: Tell the mock what data to return when a certain method is called (e.g., return a predefined user object).

* Verify interactions: Confirm that a specific method on the dependency was called, and with the correct parameters.

This makes your tests faster, more reliable, and independent of external systems.

## 2. Mocks vs. Stubs vs. Fakes 🎭

The term "mock" is often used broadly, but it's helpful to understand the different types of "test doubles":
|Term|Purpose|Use Case|
|---|---|---|
|Fake|Objects that have working implementations but are simplified.| Using an in-memory database instead of a real one.|
|Stub|Objects that provide canned, predefined answers to method calls.|Returning a specific user object whenever the GetUserById method is called.|
|Mock|Objects that provide canned answers and also verify that certain methods were called.|Verifying that the SaveUser method was called exactly once after a user is created.|

In practice, many mocking frameworks combine the functionality of mocks and stubs, allowing you to both configure behavior and verify interactions.

## 3. Practical Example with Moq 🎯

Moq is one of the most popular and easy-to-use mocking frameworks for C#. It's highly recommended for unit testing.

Let's set up a simple scenario: a ProductService that depends on a IProductRepository to get product information.

3.1 The Code to TestFirst, we define the interface and the service. Notice that ProductService is dependent on the IProductRepository interface.

```C#
// The dependency interface
public interface IProductRepository
{
    Product GetProductById(int id);
}

// The model
public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
}

// The service we want to test
public class ProductService
{
    private readonly IProductRepository _repository;

    public ProductService(IProductRepository repository)
    {
        _repository = repository;
    }

    public decimal GetTotalPrice(int id)
    {
        var product = _repository.GetProductById(id);
        if (product == null)
        {
            return 0;
        }
        return product.Price;
    }
}
```

3.2 The Unit Test with Moq

We'll use a unit test framework like NUnit or xUnit. The Moq library provides a fluent API for creating mock objects.

```C#
using Moq;
using NUnit.Framework;

[TestFixture]
public class ProductServiceTests
{
    [Test]
    public void GetTotalPrice_ReturnsCorrectPrice_WhenProductExists()
    {
        // Arrange
        // 1. Create a mock object for the dependency. The <IProductRepository> specifies the interface to mock.
        var mockRepository = new Mock<IProductRepository>();

        // 2. Set up the mock's behavior.
        //    When GetProductById(1) is called on the mock, it should return a new Product instance.
        mockRepository.Setup(repo => repo.GetProductById(1))
                      .Returns(new Product { Id = 1, Name = "Laptop", Price = 1200.00m });

        // 3. Inject the mock into the service we are testing.
        var productService = new ProductService(mockRepository.Object);

        // Act
        // Call the method we want to test.
        decimal totalPrice = productService.GetTotalPrice(1);

        // Assert
        // Verify that the result is what we expect.
        Assert.AreEqual(1200.00m, totalPrice);

        // Optional: Verify that the mock's method was called exactly once.
        mockRepository.Verify(repo => repo.GetProductById(1), Times.Once);
    }
}
```

In this example, we successfully tested the ProductService without ever needing a real IProductRepository implementation or a real database.

## 4. Exercises ✍️

1. Mocking a null Return: Modify the GetTotalPrice_ReturnsCorrectPrice_WhenProductExists test above. Create a new test case named GetTotalPrice_ReturnsZero_WhenProductDoesNotExist where you set up the mock repository to return null when the GetProductById method is called. Ensure your test asserts that the result is 0.

2. Mocking a Dependency with Multiple Methods: Create a new service called OrderService that has a dependency on both IProductRepository and a new ICustomerRepository. The OrderService should have a method PlaceOrder(int customerId, int productId) that retrieves the customer and product, and then uses a mocked IEmailService to send a confirmation email.

* Create the ICustomerRepository and IEmailService interfaces.
* Create a Customer model.
* Write the OrderService class.
* Write a unit test for OrderService.PlaceOrder() that uses mocks for all dependencies and verifies that IEmailService.SendEmail() was called.