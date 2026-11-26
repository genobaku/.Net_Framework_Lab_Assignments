# Assignment 4: Questions and Answers Related to Delegates

## Question 1: What is a delegate in C#? Explain its purpose and write the general syntax for declaring and using a delegate.

### What is a Delegate?
A delegate in C# is a type-safe function pointer. It is a reference type that encapsulates a reference to a method with a specific signature and return type. Unlike C/C++ function pointers, C# delegates are object-oriented, strongly typed, and secure.

### Purpose of Delegates:
1. Callback Methods: Allows a method to notify another method upon completing a task.
2. Event Handling: Acts as the foundational mechanism for events and event-driven programming in .NET.
3. Method Decoupling: Decouples the caller from the target method, enabling flexible and pluggable architectures.
4. Passing Methods as Parameters: Enables passing methods as arguments to higher-order functions (such as LINQ operations).

### General Syntax:

1. Declaration:
```csharp
[access_modifier] delegate return_type DelegateName(parameter_list);
```
Example:
```csharp
public delegate int Operation(int a, int b);
```

2. Instantiation:
```csharp
DelegateName del = new DelegateName(TargetMethod);
// Or using method group conversion:
DelegateName del = TargetMethod;
```

3. Invocation:
```csharp
return_type result = del(arguments);
// Or explicitly:
return_type result = del.Invoke(arguments);
```

---

## Question 2: Create a delegate that accepts two integer values and returns their sum. Create an appropriate method and invoke it using the delegate.

### Concept:
A delegate with two integer parameters and an integer return type is declared. A method matching this signature performs addition and returns the result.

### Syntax Outline:
```csharp
public delegate int SumDelegate(int a, int b);

public static int Add(int a, int b)
{
    return a + b;
}

SumDelegate del = Add;
int sum = del(10, 20);
```

---

## Question 3: Explain the difference between unicast and multicast delegates.

### Unicast Delegate:
- Points to exactly one method at any given time.
- When invoked, only that single method is executed.
- Assigned using the simple assignment operator (`=`).

### Multicast Delegate:
- Holds references to multiple methods simultaneously.
- Internally inherits from `System.MulticastDelegate` (which inherits from `System.Delegate`).
- Methods are added using the addition assignment operator (`+=`) and removed using the subtraction assignment operator (`-=`).
- When invoked, all referenced methods are called in the order they were added (invocation list).
- If the methods return a value, only the return value of the last executed method is returned unless `GetInvocationList()` is used.

### Comparison Table:

| Feature | Unicast Delegate | Multicast Delegate |
| :--- | :--- | :--- |
| Number of Methods | Single method | Multiple methods |
| Operator Used | `=` | `+=` and `-=` |
| Invocation Order | Single execution | Sequential order |
| Return Value | Returns result of the method | Returns result of the last method |
| Common Use Case | Immediate callbacks, single targets | Event dispatching, broadcast notifications |

---

## Question 4: Create a delegate for a calculator application. Use the same delegate to invoke methods for addition, subtraction, multiplication, and division.

### Concept:
A single delegate type `delegate double CalculatorDelegate(double a, double b)` can hold references to any method matching its signature. By reassigning the delegate variable to `Add`, `Subtract`, `Multiply`, and `Divide`, all four operations are executed through the same delegate reference.

---

## Question 5: A notification system can send notifications using Email, SMS, and WhatsApp. Create a multicast delegate that invokes methods representing these three notification services.

### Concept:
Define three methods (`SendEmail`, `SendSms`, `SendWhatsApp`) sharing the signature `void (string message)`. Combine them into a single multicast delegate using `+=`. A single invocation triggers all three notification channels.

---

## Question 6: Employee Salary Calculation using Multicast Delegate and GetInvocationList()

### Components:
1. Basic Salary (100% of basic)
2. HRA (20% of basic)
3. DA (10% of basic)
4. Bonus (15% of basic)

### Why GetInvocationList() is Required:
When a multicast delegate points to methods that return values, a direct invocation only returns the result of the last method in the chain. To capture the return value of every method, `GetInvocationList()` is called to retrieve each individual delegate, invoke it separately, and accumulate the components.

---

## Question 7: Displaying Method Names and Invoking Individually via GetInvocationList()

### Concept:
`GetInvocationList()` returns an array of `Delegate` objects (`Delegate[]`). Each object provides metadata via reflection:
- `del.Method.Name`: Returns the string name of the target method.
- `del.DynamicInvoke(...)`: Invokes the specific delegate instance individually with arguments.

---

## Question 8: What is the built-in Action delegate?

### What is Action?
`Action` is a built-in generic delegate provided in the `System` namespace. It represents a method that takes zero or more parameters (up to 16 parameters) and does not return a value (`void`).

### Syntax:
```csharp
Action
Action<T>
Action<T1, T2>
...
Action<T1, T2, ..., T16>
```

### Key Characteristics:
1. Always has a return type of `void`.
2. Eliminates the need to declare custom delegate types for void-returning methods.
3. Supports both unicast and multicast assignment.

---

## Question 9: What is the built-in Func delegate?

### What is Func?
`Func` is a built-in generic delegate defined in the `System` namespace. It represents a method that takes zero or more input parameters (up to 16) and returns a value.

### Syntax:
```csharp
Func<TResult>
Func<T, TResult>
Func<T1, T2, TResult>
...
Func<T1, T2, ..., T16, TResult>
```

### Key Characteristics:
1. The last type parameter always specifies the return type.
2. Preceding type parameters specify input parameter types.
3. Used extensively in LINQ queries and functional programming in C#.

---

## Question 10: What is the built-in Predicate delegate?

### What is Predicate?
`Predicate<T>` is a built-in generic delegate defined in the `System` namespace that accepts exactly one parameter of type `T` and always returns a `bool`.

### Syntax:
```csharp
public delegate bool Predicate<in T>(T obj);
```

### Key Characteristics:
1. Always returns `true` or `false`.
2. Commonly used for evaluation, filtering, search conditions, and validation criteria (e.g., `List<T>.FindAll`, `List<T>.Exists`).
3. Equivalent to `Func<T, bool>`.
