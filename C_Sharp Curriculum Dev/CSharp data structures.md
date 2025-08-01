<!-- AI prompt: create some C# content for a class on the topic of C# data structures, include exercises and real world project examples. Output the file into markdown language. -->

C# Data Structures: A Comprehensive GuideWelcome to this comprehensive guide on C# Data Structures! In the world of programming, data structures are fundamental. They are specialized ways of organizing and storing data in a computer so that it can be accessed and modified efficiently. Understanding data structures is crucial for writing efficient, scalable, and maintainable C# applications.

This guide will cover the most common and essential data structures, providing explanations, C# implementation examples, a look into their performance characteristics, practical exercises, and real-world project examples.Let's dive in!

1. Arrays  
**Explanation**  
An array is a collection of elements of the same data type stored at contiguous memory locations. In C#, arrays are zero-indexed, meaning the first element is at index 0. They have a fixed size, which must be specified at the time of declaration.

**Use Cases**  
* Storing a fixed number of items of the same type.
* Implementing other data structures like stacks or queues.
* When direct access to elements by index is required.

C# Implementation Example// 
```C#
Declaring and initializing an array of integers

int[] numbers = new int[5]; // An array to hold 5 integers

// Assigning values
numbers[0] = 10;
numbers[1] = 20;
numbers[2] = 30;
numbers[3] = 40;
numbers[4] = 50;

// Accessing values
Console.WriteLine($"First element: {numbers[0]}"); // Output: First element: 10

// Iterating through an array
Console.WriteLine("All elements:");
foreach (int num in numbers)
{
    Console.WriteLine(num);
}

// Array initialization shorthand
string[] names = { "Alice", "Bob", "Charlie" };
Console.WriteLine($"Number of names: {names.Length}"); // Output: Number of names: 3
```

Performance Characteristics
* Access: (Read/Write): O(1) - Constant time. Because elements are stored contiguously, the memory address of any element can be calculated directly using its index.
* Insertion/Deletion: O(n) - Linear time. If you insert or delete an element in the middle, all subsequent elements need to be shifted, which can be expensive for large arrays.
* Space Complexity: O(n) - Linear time. An array occupies space proportional to the number of elements it stores.

Exercise 1: Array Reversal  
Write a C# program that takes an array of integers and reverses its elements in place. Do not use any built-in Reverse() methods.

2. Lists (List`<T>`)
**Explanation**  
List`<T>` is a generic collection that represents a strongly typed list of objects that can be accessed by index. It is part of the System.Collections.Generic namespace and is essentially a dynamic array, meaning its size can grow or shrink as needed. Internally, List`<T>` uses an array. When the internal array becomes full, a new, larger array is allocated, and the elements are copied over.

**Use Cases** 
* When you need a dynamic collection that can grow or shrink.
* Frequent element access by index.
* Adding or removing elements frequently (though performance varies based on position).

C# Implementation Example

```C#
// Declaring and initializing a List of strings
List<string> fruits = new List<string>();

// Adding elements
fruits.Add("Apple");
fruits.Add("Banana");
fruits.Add("Cherry");

// Accessing elements by index
Console.WriteLine($"Second fruit: {fruits[1]}"); // Output: Second fruit: Banana

// Inserting an element
fruits.Insert(1, "Orange"); // Inserts "Orange" at index 1
Console.WriteLine("Fruits after insertion:");
foreach (string fruit in fruits)
{
    Console.WriteLine(fruit);
}
// Output:
// Apple
// Orange
// Banana
// Cherry

// Removing an element
fruits.Remove("Banana"); // Removes the first occurrence of "Banana"
fruits.RemoveAt(0);      // Removes element at index 0 (Apple)
Console.WriteLine("Fruits after removal:");
foreach (string fruit in fruits)
{
    Console.WriteLine(fruit);
}
// Output:
// Orange
// Cherry

// Checking count
Console.WriteLine($"Current number of fruits: {fruits.Count}"); // Output: Current number of fruits: 2
```

**Performance Characteristics**
* Access (Read/Write): O(1) - Constant time for direct index access.  
* Add (at end): Amortized O(1) - Constant time. Most additions are fast. When the internal array needs to be resized, it's O(n) for copying, but this happens infrequently, so the average cost is constant.
* Insert (at middle/beginning): O(n) - Linear time. Elements need to be shifted to make space.
* Remove (at middle/beginning): O(n) - Linear time. Elements need to be shifted to fill the gap.Remove (at end): O(1) - Constant time. No shifting required.
* Space Complexity: O(n) - Linear time.

Exercise 2: Unique Elements  
Given a List`<int>`, write a C# method that returns a new List`<int>` containing only the unique elements from the original list, preserving their original order.

3. Stacks (Stack`<T>`)  
**Explanation:**
A stack is a Last-In, First-Out (LIFO) data structure. Imagine a stack of plates: you can only add a new plate to the top, and you can only remove the top plate.

**Use Cases**
* Function call stack (how methods are executed and returned).
* Undo/Redo functionality in applications.
* Expression evaluation (e.g., postfix expressions).
* Backtracking algorithms.

**C# Implementation Example**
```C#
// Declaring and initializing a Stack of characters
Stack<char> charStack = new Stack<char>();

// Pushing elements onto the stack
charStack.Push('A');
charStack.Push('B');
charStack.Push('C');

Console.WriteLine($"Top element (Peek): {charStack.Peek()}"); // Output: Top element (Peek): C

// Popping elements from the stack
char poppedChar = charStack.Pop();
Console.WriteLine($"Popped element: {poppedChar}"); // Output: Popped element: C

Console.WriteLine($"Top element after pop: {charStack.Peek()}"); // Output: Top element after pop: B

// Iterating through the stack (note: order is not guaranteed for iteration, only for Pop)
Console.WriteLine("Elements in stack (iteration order):");
foreach (char c in charStack)
{
    Console.WriteLine(c);
}
// Output (might vary, but typically LIFO order for iteration):
// B
// A

charStack.Pop(); // Popped B
charStack.Pop(); // Popped A

Console.WriteLine($"Is stack empty? {charStack.Count == 0}"); // Output: Is stack empty? True
```

**Performance Characteristics**
* Push (Add to top): O(1) - Constant time.
* Pop (Remove from top): O(1) - Constant time.
* Peek (View top): O(1) - Constant time.
* Space Complexity: O(n) - Linear time.

**Exercise 3: Parentheses Checker**  
Write a C# method that takes a string containing parentheses (), curly braces {}, and square brackets []. The method should return true if the parentheses are balanced and correctly nested, and false otherwise. Use a stack to solve this.

Example:  
"([])" -> true"  
([)]" -> false"  
{[()]}" -> true"  
(((" -> false

4. Queues (Queue`<T>`)  
**Explanation**  
A queue is a First-In, First-Out (FIFO) data structure. Think of a line at a supermarket: the first person in line is the first person to be served.

Use Cases  
* Task scheduling (e.g., print queue, CPU scheduling).
* Message buffering.  
* Breadth-First Search (BFS) algorithms.
* Handling requests in a specific order.

C# Implementation Example
```C#
// Declaring and initializing a Queue of strings
Queue<string> customerQueue = new Queue<string>();

// Enqueuing elements (adding to the back)
customerQueue.Enqueue("Alice");
customerQueue.Enqueue("Bob");
customerQueue.Enqueue("Charlie");

Console.WriteLine($"Next customer (Peek): {customerQueue.Peek()}"); // Output: Next customer (Peek): Alice

// Dequeuing elements (removing from the front)
string servedCustomer = customerQueue.Dequeue();
Console.WriteLine($"Served customer: {servedCustomer}"); // Output: Served customer: Alice

Console.WriteLine($"Next customer after dequeue: {customerQueue.Peek()}"); // Output: Next customer after dequeue: Bob

// Checking count
Console.WriteLine($"Customers remaining: {customerQueue.Count}"); // Output: Customers remaining: 2

// Iterating through the queue (order is guaranteed)
Console.WriteLine("Customers in queue:");
foreach (string customer in customerQueue)
{
    Console.WriteLine(customer);
}
// Output:
// Bob
// Charlie
```

**Performance Characteristics**  
* Enqueue (Add to back): O(1) - Constant time.
* Dequeue (Remove from front): O(1) - Constant time.
* Peek (View front): O(1) - Constant time.
* Space Complexity: O(n) - Linear time.

**Exercise 4: Simple Task Scheduler**  
Implement a simple task scheduler using a Queue`<string>`. Users can "add" tasks, and the scheduler can "execute" the next task. Display the current task queue after each operation.

5. HashSets (HashSet<T>)  
**Explanation**  
A HashSet`<T>` is a collection of unique elements. It is an unordered collection that stores distinct elements and provides very fast operations for adding, removing, and checking for the presence of elements. It achieves this efficiency by using a hash table internally.  

**Use Cases**  
* Storing a collection of unique items.
* Performing set operations like union, intersection, and difference.
* Quickly checking if an item exists in a collection.

**C# Implementation Example**

```C#
// Declaring and initializing a HashSet of integers
HashSet<int> uniqueNumbers = new HashSet<int>();

// Adding elements
uniqueNumbers.Add(10);
uniqueNumbers.Add(20);
uniqueNumbers.Add(30);
uniqueNumbers.Add(20); // This will not be added as 20 already exists

Console.WriteLine("Unique numbers in HashSet:");
foreach (int num in uniqueNumbers)
{
    Console.WriteLine(num);
}
// Output (order is not guaranteed):
// 10
// 20
// 30

// Checking for existence
Console.WriteLine($"Contains 20? {uniqueNumbers.Contains(20)}"); // Output: Contains 20? True
Console.WriteLine($"Contains 50? {uniqueNumbers.Contains(50)}"); // Output: Contains 50? False

// Removing an element
uniqueNumbers.Remove(10);
Console.WriteLine($"Contains 10 after removal? {uniqueNumbers.Contains(10)}"); // Output: Contains 10 after removal? False

// Set operations
HashSet<int> setA = new HashSet<int> { 1, 2, 3, 4 };
HashSet<int> setB = new HashSet<int> { 3, 4, 5, 6 };

setA.UnionWith(setB); // setA now contains {1, 2, 3, 4, 5, 6}
Console.WriteLine("Union of A and B:");
foreach (int num in setA) Console.Write($"{num} ");
Console.WriteLine();

setA = new HashSet<int> { 1, 2, 3, 4 }; // Reset setA
setA.IntersectWith(setB); // setA now contains {3, 4}
Console.WriteLine("Intersection of A and B:");
foreach (int num in setA) Console.Write($"{num} ");
Console.WriteLine();
```

**Performance Characteristics**  
* Add, Remove, Contains: Average O(1) - Constant time. In the worst case (due to hash collisions), it can degrade to O(n), but this is rare with a good hash function.
* Space Complexity: O(n) - Linear time.

**Exercise 5: Find Duplicates**

Given a List`<string>`, write a C# method that identifies and returns all duplicate strings in the list. Use a HashSet`<T>` to efficiently track seen elements.

6. Dictionaries (Dictionary`<TKey, TValue>`)  
**Explanation**  
A Dictionary`<TKey, TValue>` is a collection of key/value pairs. Each key must be unique, and it maps to a single value. It provides very fast lookups based on the key, similar to a real-world dictionary where you look up a word (key) to find its definition (value). Like HashSet<T>, it uses a hash table internally.

**Use Cases**  
* Storing configuration settings (key-value pairs).
* Caching data where quick lookups by a unique identifier are needed.
* Implementing frequency counters.
* Representing relationships where one item uniquely identifies another.

C# Implementation Example
```C#
// Declaring and initializing a Dictionary with string keys and int values
Dictionary<string, int> studentGrades = new Dictionary<string, int>();

// Adding key-value pairs
studentGrades.Add("Alice", 95);
studentGrades.Add("Bob", 88);
studentGrades.Add("Charlie", 72);

// Accessing values by key
Console.WriteLine($"Alice's grade: {studentGrades["Alice"]}"); // Output: Alice's grade: 95

// Updating a value
studentGrades["Bob"] = 90;
Console.WriteLine($"Bob's new grade: {studentGrades["Bob"]}"); // Output: Bob's new grade: 90

// Checking if a key exists
Console.WriteLine($"Contains key 'Charlie'? {studentGrades.ContainsKey("Charlie")}"); // Output: Contains key 'Charlie'? True
Console.WriteLine($"Contains key 'David'? {studentGrades.ContainsKey("David")}");   // Output: Contains key 'David'? False

// Trying to get a value safely
int davidGrade;
if (studentGrades.TryGetValue("David", out davidGrade))
{
    Console.WriteLine($"David's grade: {davidGrade}");
}
else
{
    Console.WriteLine("David not found in dictionary."); // Output: David not found in dictionary.
}

// Iterating through key-value pairs
Console.WriteLine("All student grades:");
foreach (KeyValuePair<string, int> entry in studentGrades)
{
    Console.WriteLine($"{entry.Key}: {entry.Value}");
}
// Output (order not guaranteed):
// Alice: 95
// Bob: 90
// Charlie: 72

// Removing a key-value pair
studentGrades.Remove("Charlie");
Console.WriteLine($"Count after removing Charlie: {studentGrades.Count}"); // Output: Count after removing Charlie: 2
```

**Performance Characteristics**  
* Add, Remove, ContainsKey, Access by Key (indexer): Average O(1) - Constant time. Similar to HashSet<T>, worst case can be O(n) due to hash collisions.
* Space Complexity: O(n) - Linear time.

**Exercise 6: Word Frequency Counter**  
Write a C# method that takes a string of text and returns a Dictionary`<string, int>` where keys are words and values are their frequencies (how many times they appear in the text). Ignore case and punctuation.

7. Linked Lists (LinkedList`<T>`)  
**Explanation**  
A linked list is a linear data structure where elements are not stored at contiguous memory locations. Instead, each element (called a node) contains data and a reference (or link) to the next node in the sequence. There are singly linked lists (nodes point only forward) and doubly linked lists (nodes point forward and backward). C#'s LinkedList`<T>` is a doubly linked list.

Use Cases
* When frequent insertions and deletions are needed at arbitrary positions.
* Implementing queues or stacks (though Queue<T> and Stack<T> are generally more optimized).
* Managing data where elements need to be reordered frequently.

**C# Implementation Example**
```C#
// Declaring and initializing a LinkedList of strings
LinkedList<string> shoppingList = new LinkedList<string>();

// Adding elements
shoppingList.AddLast("Milk");
shoppingList.AddFirst("Bread");
shoppingList.AddLast("Eggs");

// List: Bread -> Milk -> Eggs

// Adding after a specific node
LinkedListNode<string> milkNode = shoppingList.Find("Milk");
if (milkNode != null)
{
    shoppingList.AddAfter(milkNode, "Cheese");
}
// List: Bread -> Milk -> Cheese -> Eggs

Console.WriteLine("Shopping List:");
foreach (string item in shoppingList)
{
    Console.WriteLine(item);
}
// Output:
// Bread
// Milk
// Cheese
// Eggs

// Removing elements
shoppingList.Remove("Bread"); // Removes "Bread"
shoppingList.RemoveFirst();   // Removes "Milk"
shoppingList.RemoveLast();    // Removes "Eggs"

Console.WriteLine("Shopping List after removals:");
foreach (string item in shoppingList)
{
    Console.WriteLine(item);
}
// Output:
// Cheese

Console.WriteLine($"Current count: {shoppingList.Count}"); // Output: Current count: 1
```

**Performance Characteristics**  
* Access (by index): O(n) - Linear time. You have to traverse the list from the beginning (or end for doubly linked lists) to reach a specific index.
* Insertion/Deletion (at known node/ends): O(1) - Constant time. If you have a reference to the node before/after the insertion/deletion point, it's just a matter of updating pointers. Adding/removing at First or Last is also O(1).
* Insertion/Deletion (by value): O(n) - Linear time. You first need to find the node, which takes O(n).
* Space Complexity: O(n) - Linear time. Each node stores data and pointers.

**Exercise 7: Merge Two Sorted Linked Lists**  
Given two sorted LinkedList`<int>` instances, write a C# method to merge them into a single sorted LinkedList`<int>`. Do not convert them to List`<T>` or arrays.

8. Trees (Binary Search Trees)  
**Explanation**  
A tree is a non-linear data structure that simulates a hierarchical tree structure, with a root value and subtrees of children with a parent node, represented as a set of linked nodes.

A Binary Search Tree (BST) is a special type of binary tree where for each node:
* All nodes in the left subtree have values less than the node's value.
* All nodes in the right subtree have values greater than the node's value.
* Both the left and right subtrees are also BSTs.

**Use Cases**  
* Efficient searching, insertion, and deletion of data (especially when data is frequently modified).
* Implementing symbol tables in compilers.
* Database indexing.
* File systems.

C# Implementation Example (Conceptual - Manual Implementation)

C# does not have a built-in Tree`<T>` class. You typically implement trees manually or use third-party libraries. Here's a basic conceptual implementation of a Binary Search Tree node and its operations:

```C#
public class TreeNode
{
    public int Value { get; set; }
    public TreeNode Left { get; set; }
    public TreeNode Right { get; set; }

    public TreeNode(int value)
    {
        Value = value;
        Left = null;
        Right = null;
    }
}

public class BinarySearchTree
{
    public TreeNode Root { get; private set; }

    public BinarySearchTree()
    {
        Root = null;
    }

    // Insert operation
    public void Insert(int value)
    {
        Root = InsertRecursive(Root, value);
    }

    private TreeNode InsertRecursive(TreeNode current, int value)
    {
        if (current == null)
        {
            return new TreeNode(value);
        }

        if (value < current.Value)
        {
            current.Left = InsertRecursive(current.Left, value);
        }
        else if (value > current.Value)
        {
            current.Right = InsertRecursive(current.Right, value);
        }
        // Value already exists, do nothing (or handle as needed)
        return current;
    }

    // Search operation
    public bool Contains(int value)
    {
        return ContainsRecursive(Root, value);
    }

    private bool ContainsRecursive(TreeNode current, int value)
    {
        if (current == null)
        {
            return false;
        }
        if (value == current.Value)
        {
            return true;
        }
        return value < current.Value
            ? ContainsRecursive(current.Left, value)
            : ContainsRecursive(current.Right, value);
    }

    // In-order traversal (prints elements in sorted order)
    public void InOrderTraversal()
    {
        InOrderTraversalRecursive(Root);
        Console.WriteLine();
    }

    private void InOrderTraversalRecursive(TreeNode node)
    {
        if (node != null)
        {
            InOrderTraversalRecursive(node.Left);
            Console.Write($"{node.Value} ");
            InOrderTraversalRecursive(node.Right);
        }
    }
}

// Usage Example:
// BinarySearchTree bst = new BinarySearchTree();
// bst.Insert(50);
// bst.Insert(30);
// bst.Insert(70);
// bst.Insert(20);
// bst.Insert(40);
// bst.Insert(60);
// bst.Insert(80);
//
// Console.WriteLine("In-order traversal:");
// bst.InOrderTraversal(); // Output: 20 30 40 50 60 70 80
//
// Console.WriteLine($"Contains 40? {bst.Contains(40)}"); // Output: Contains 40? True
// Console.WriteLine($"Contains 90? {bst.Contains(90)}"); // Output: Contains 90? False
```

**Performance Characteristics (for a balanced BST)**  
* Search, Insertion, Deletion: Average O(logn) - Logarithmic time. This is because at each step, you eliminate half of the remaining nodes.
* Worst Case (unbalanced tree): O(n) - Linear time. If the tree becomes skewed (e.g., elements inserted in strictly increasing order), it degenerates into a linked list.
* Space Complexity: O(n) - Linear time.

Exercise 8: Delete Node from BST

Extend the BinarySearchTree class to include a Delete(int value) method. This is a more complex operation, especially handling nodes with two children.

9. Graphs

**Explanation**

A graph is a non-linear data structure consisting of a finite set of vertices (or nodes) and a set of edges connecting pairs of vertices. Graphs can be:  
* Directed: Edges have a direction (e.g., A -> B).  
* Undirected: Edges have no direction (e.g., A -- B).
* Weighted: Edges have associated values (weights), often representing cost or distance.

Representations

* Adjacency Matrix: A 2D array where matrix[i][j] is 1 (or weight) if there's an edge from i to j, and 0 otherwise.
* Adjacency List: An array or list where each index represents a vertex, and the value at that index is a list of its neighbors. This is generally preferred for sparse graphs (fewer edges).

**Use Cases**

* Social networks (users as nodes, friendships as edges).
* Navigation systems (locations as nodes, roads as edges).
* Network topologies.Dependency tracking (e.g., project tasks).
* Pathfinding algorithms (Dijkstra's, A*).

**C# Implementation Example (Adjacency List)**

```C#
using System.Collections.Generic;

public class Graph
{
    private int V; // Number of vertices
    private List<int>[] adj; // Adjacency List

    public Graph(int v)
    {
        V = v;
        adj = new List<int>[v];
        for (int i = 0; i < v; ++i)
        {
            adj[i] = new List<int>();
        }
    }

    // Add an edge to the graph (undirected)
    public void AddEdge(int v1, int v2)
    {
        adj[v1].Add(v2);
        adj[v2].Add(v1); // For undirected graph
    }

    // Add a directed edge
    public void AddDirectedEdge(int v1, int v2)
    {
        adj[v1].Add(v2);
    }

    // Breadth-First Search (BFS) Traversal
    public void BFS(int startNode)
    {
        bool[] visited = new bool[V];
        Queue<int> queue = new Queue<int>();

        visited[startNode] = true;
        queue.Enqueue(startNode);

        Console.Write($"BFS starting from {startNode}: ");
        while (queue.Count > 0)
        {
            int currentNode = queue.Dequeue();
            Console.Write($"{currentNode} ");

            foreach (int neighbor in adj[currentNode])
            {
                if (!visited[neighbor])
                {
                    visited[neighbor] = true;
                    queue.Enqueue(neighbor);
                }
            }
        }
        Console.WriteLine();
    }

    // Depth-First Search (DFS) Traversal
    public void DFS(int startNode)
    {
        bool[] visited = new bool[V];
        Console.Write($"DFS starting from {startNode}: ");
        DFSUtil(startNode, visited);
        Console.WriteLine();
    }

    private void DFSUtil(int node, bool[] visited)
    {
        visited[node] = true;
        Console.Write($"{node} ");

        foreach (int neighbor in adj[node])
        {
            if (!visited[neighbor])
            {
                DFSUtil(neighbor, visited);
            }
        }
    }
}

// Usage Example:
// Graph g = new Graph(5); // 5 vertices (0 to 4)
// g.AddEdge(0, 1);
// g.AddEdge(0, 2);
// g.AddEdge(1, 3);
// g.AddEdge(2, 4);
// g.AddEdge(3, 4);
//
// g.BFS(0); // Output: BFS starting from 0: 0 1 2 3 4
// g.DFS(0); // Output: DFS starting from 0: 0 1 3 4 2 (order might vary slightly for DFS)
```

**Performance Characteristics**
* Adjacency List:
    * Space: O(V+E) where V is number of vertices and E is number of edges.
    * Adding Edge: O(1) (for AddEdge to list).
    * Checking if edge exists: O(textdegreeofvertex) in worst case, O(1) on average if optimized with HashSet for neighbors.
    * Traversal (BFS/DFS): O(V+E).
* Adjacency Matrix:
    * Space: O(V2).
    * Adding Edge: O(1).
    * Checking if edge exists: O(1).
    * Traversal (BFS/DFS): O(V2).Adjacency lists are generally more space-efficient for sparse graphs, while adjacency matrices are better for dense graphs or when quick edge_exists checks are paramount.
    
    **Exercise 9: Find All Paths in a Graph**
    
    Given a Graph and two nodes, startNode and endNode, write a C# method that finds and prints all possible paths from startNode to endNode.
    
    ### Real-World Project Examples
    
    **Project 1: Simple Social Network (Graph)**
    
    Imagine building a very basic social network. You can represent users as nodes and friendships as undirected edges in a graph.
    
    Data Structures Used:
    
    * Dictionary`<string, List<string>>` or Dictionary`<string, HashSet<string>>` for the adjacency list (mapping user names to their friends).
    * Queue`<string>` for Breadth-First Search (to find friends of friends).
    * Stack`<string>` for Depth-First Search (to explore connections).
    
    Example Features:
    
    * Add User
    * Add Friendship (connect two users)
    * Find all friends of a user
    * Find shortest path (degrees of separation) between two users (using BFS)
    * Check if two users are connected (using BFS/DFS)
    
    **Project 2: Document Indexer (Dictionary, HashSet)**
    
    Create a program that indexes text documents. For each document, you want to store a list of unique words and their frequencies. You also want to be able to quickly search for documents containing specific words.
    
    Data Structures Used:
    
    * Dictionary`<string, Dictionary<string, int>>`: Outer dictionary maps document names (keys) to an inner dictionary. The inner dictionary maps words (keys) to their frequencies (values) within that document.
    * HashSet`<string>`: To efficiently get unique words from a document before counting frequencies.
    * List`<string>`: To store the list of documents found for a search query.
    
    Example Features:
    
    * Add Document: Parse text, extract words, count frequencies, store in the main dictionary.
    * Search Word: Given a word, return a list of document names that contain that word.
    * Get Word Frequency in Document: Given a document name and a word, return how many times the word appears.
    
    **Project 3: Undo/Redo System for a Text Editor (Stack)**
    
    Implement a basic undo/redo functionality for a simplified text editor.
    
    Data Structures Used:
    
    * Stack`<string>`: One stack for "undo" operations, and another for "redo" operations. Each entry in the stack could be the state of the text before an operation.
    
    Example Features:
    
    * Type/Edit: When the user types, push the current text state onto the undo stack. Clear the redo stack.
    * Undo: Pop from the undo stack, apply the state, and push the current state onto the redo stack.
    * Redo: Pop from the redo stack, apply the state, and push the current state onto the undo stack.
    
    ### Conclusion
    
    Understanding and effectively utilizing C# data structures is a cornerstone of becoming a proficient developer. Each data structure has its strengths and weaknesses, making it suitable for different scenarios. By mastering their characteristics and performance implications, you can make informed decisions that lead to more efficient and robust applications.Keep practicing with the exercises and try to think about how these data structures are used in the software you interact with daily. Happy coding!