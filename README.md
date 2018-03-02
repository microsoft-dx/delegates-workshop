## What are delegates?

> A [delegate](https://msdn.microsoft.com/en-us/library/900fyy8e.aspx) is a type that represents references to methods with a particular parameter list and return type. Delegates are used to pass methods as arguments to other methods. You create a custom method, and a class such as a windows control can call your method when a certain event occurs.
> 
> [More on the official MSDN documentation](https://msdn.microsoft.com/en-us/library/ms173171.aspx)

## What are events?

> Events enable a [class](https://msdn.microsoft.com/en-us/library/0b0thckt.aspx) or object to notify other classes or objects when something of interest occurs. The class that sends (or _raises_) the event is called the _publisher_ and the classes that receive (or _handle_) the event are called _subscribers_.
> 
> [More on the official MSDN documentation](https://msdn.microsoft.com/en-us/library/awbftdfh.aspx)

## Understanding ExampleBase.cs

In order to showcase delegates we need, obviously, a delegate method, hence the `delegate void ExecuteOperation(double x, double y)`. This particular example uses basic mathematical operations, hence the `Add`, `Substract`, `Multiply`, `Divide` methods. To provide a feedback and get the results of those mathematical operations we need to print something to the screen, hence the `void DisplayResult(Operation operationType, double value)`. In order to abstractly print the result to the screen while maintaing the operation it processed, we need an extra argument, hence the `Operation enum`. In order to encapsulate the functionality, we need a way to put everything in motion while also maintaing privacy, hence the `public abstract void Run()` method wich will be implemented in every child class.

## Simple delegates

To keep it simple, delegates are methods used as variables, similar to [pointers to functions in C](https://en.wikipedia.org/wiki/Function_pointer). In this case, we have one delegate variable per mathematical operation, so in order to compute each result we have to call each delegate separately.

```csharp
var addOperation = new ExecuteOperation(AddOperation);
var substractOperation = new ExecuteOperation(SubstractOperation);
var multiplyOperation = new ExecuteOperation(MultiplyOperation);
var divideOperation = new ExecuteOperation(DivideOperation);

addOperation(2, 3);
substractOperation(5, 3);
multiplyOperation(10, 2);
divideOperation(20, 4);
```

[![01](https://github.com/microsoft-dx/delegates-workshop/tree/master/Images/01-5.png)](https://github.com/microsoft-dx/delegates-workshop/tree/master/Images/01-5.png)

## Multiple delegates

We can have multiple delegates assigned to the same variable, in which case all methods are called. To add a delegate to a variabile we use the `+=` operator and for removing a delegate, we use the `-=` delegate. Imagine a scenario where whenever a person enters the room, a [jingle bell](https://www.youtube.com/watch?v=5vyMuxxLsD0) will be heard. Now imagine that you want to extend the functionality to also take a picture of the person entering the room. In order to do this you will have to integrate your logging system without any knowledge about how the original code was written, you have to dig the code for the place where the event is called and so on. But if you implemented with delegates, it is easy to expose the delegate method in an interface and all you have to do is implement that method and simply add your picture logging delegate action to the delegate object.

```csharp
ExecuteOperation mathOperations = null;

mathOperations += new ExecuteOperation(AddOperation);
mathOperations += new ExecuteOperation(SubstractOperation);
mathOperations += new ExecuteOperation(MultiplyOperation);
mathOperations += new ExecuteOperation(DivideOperation);

mathOperations(40, 5);
```

[![01](https://github.com/microsoft-dx/delegates-workshop/tree/master/Images/01-6.png)](https://github.com/microsoft-dx/delegates-workshop/tree/master/Images/01-6.png)

## Anonymous methods

> In versions of C# before 2.0, the only way to declare a [delegate](https://msdn.microsoft.com/en-us/library/900fyy8e.aspx) was to use [named methods](https://msdn.microsoft.com/en-us/library/98dc08ac.aspx). C# 2.0 introduced anonymous methods and in C# 3.0 and later, lambda expressions supersede anonymous methods as the preferred way to write inline code. By using anonymous methods, you reduce the coding overhead in instantiating delegates because you do not have to create a separate method.
> 
> [More on the official MSDN documentation](https://msdn.microsoft.com/en-us/library/0yw3tz5k.aspx)

If you don't want to create a method on its own, you can create an anonymous one instead and place it inside the method you want to use it. The functionality is the same as a named method, only that the scope is limited to the context in which you write it.

```csharp
ExecuteOperation addOperation = delegate (double x, double y)
{
    DisplayResult(Operation.Add, x + y);
};

ExecuteOperation substractOperation = delegate (double x, double y)
{
    DisplayResult(Operation.Substract, x - y);
};

ExecuteOperation multiplyOperation = delegate (double x, double y)
{
    DisplayResult(Operation.Multiply, x * y);
};

ExecuteOperation divideOperation = delegate (double x, double y)
{
    DisplayResult(Operation.Divide, x / y);
};

addOperation(2, 3);
substractOperation(5, 3);
multiplyOperation(10, 2);
divideOperation(20, 4);
```

[![01](https://github.com/microsoft-dx/delegates-workshop/tree/master/Images/01-7.png)](https://github.com/microsoft-dx/delegates-workshop/tree/master/Images/01-7.png)

## Lambda delegates

> A lambda expression is an [anonymous function](https://msdn.microsoft.com/en-us/library/0yw3tz5k.aspx) that you can use to create [delegates](https://msdn.microsoft.com/en-us/library/ms173172.aspx) or [expression tree](https://msdn.microsoft.com/en-us/library/bb397951.aspx) types. By using lambda expressions, you can write local functions that can be passed as arguments or returned as the value of function calls. Lambda expressions are particularly helpful for writing LINQ query expressions.
> 
> [More on the official MSDN documentation](https://msdn.microsoft.com/en-us/library/bb397687.aspx)

If you don't want to create a method on its own, and you want to rely on the [lambda calculus concept](https://en.wikipedia.org/wiki/Lambda_calculus) you can create a lambda method, which basically is a plain anonymous method. The functionality is the same as a named or anonymous method, but the power of lambda methods comes with LINQ query expressions (more on this soon 😎).

```csharp
ExecuteOperation addOperation = (x, y) => DisplayResult(Operation.Add, x + y);

ExecuteOperation substractOperation = (x, y) => DisplayResult(Operation.Substract, x - y);

ExecuteOperation multiplyOperation = (x, y) =>
{
    DisplayResult(Operation.Multiply, x * y);
};

ExecuteOperation divideOperation = (x, y) =>
{
    DisplayResult(Operation.Divide, x / y);
};

addOperation(2, 3);
substractOperation(5, 3);
multiplyOperation(10, 2);
divideOperation(20, 4);
```

[![](https://github.com/microsoft-dx/delegates-workshop/tree/master/Images/01-8.png)](https://github.com/microsoft-dx/delegates-workshop/tree/master/Images/01-8.png)

## Asynchronous delegates

If your brain didn't melt by now you're good, but I am sure that with this chapter it will. All delegates have the ability to run on threads, which is a very cool feature introduced by the Asynchronous Programming Model (APM) (you can check more about this topic [here](https://laurentiu.microsoft.pub.ro/2016/08/14/from-eap-to-tap-in-csharp/)). In this example, we run each mathematical operation on a separate thread and after it finishes we run a [callback](https://en.wikipedia.org/wiki/Callback_(computer_programming)) in which we terminate the thread. In this example, after a thread finishes its work, it prints a message to the screen. We then call the `EndInvoke` method to terminate the thread which does not necessarily end when the main thread ends nor does the operations or callbacks executed in the written order (as you can see in the output). So in order for us to see the messages from the callback methods, we need to wait for them to finish either by using [async/await](https://laurentiu.microsoft.pub.ro/2016/08/07/asynchronous-programming-in-csharp/) or by synchronization with the main thread (putting the main thread on sleep because thread synchronization isn't the purpose of this post) (more on multithreading [here](https://en.wikipedia.org/wiki/Multithreading_(computer_architecture))).

```csharp
private void ExecuteOperationCallback(IAsyncResult asyncResult)
{
    var result = asyncResult as AsyncResult;
    var caller = result.AsyncDelegate as ExecuteOperation;
    var operation = (Operation)result.AsyncState;

    Console.WriteLine("--> The {0} operation finished", operation);

    caller.EndInvoke(asyncResult);
}

public override void Run()
{
    Console.WriteLine("=== Asynchronous Delegates Example ===");

    var addOperation = new ExecuteOperation(AddOperation);
    var substractOperation = new ExecuteOperation(SubstractOperation);
    var multiplyOperation = new ExecuteOperation(MultiplyOperation);
    var divideOperation = new ExecuteOperation(DivideOperation);

    var operationCallback = new AsyncCallback(ExecuteOperationCallback);

    addOperation.BeginInvoke(2, 3, operationCallback, Operation.Add);
    substractOperation.BeginInvoke(5, 3, operationCallback, Operation.Substract);
    multiplyOperation.BeginInvoke(10, 2, operationCallback, Operation.Multiply);
    divideOperation.BeginInvoke(20, 4, operationCallback, Operation.Divide);

    /*
     * We need this because the callbacks are made on background threads
     * which don't necessarily finish when the main thread exits
     */
    Thread.Sleep(1000);
    Console.WriteLine();
}
```

[![01](https://github.com/microsoft-dx/delegates-workshop/tree/master/Images/01-9.png)](https://github.com/microsoft-dx/delegates-workshop/tree/master/Images/01-9.png)

## In conclusion

As you may have observed, a bit of C# coding knowledge is required. For a better understanding of how powerful the C# language really is, you can check out [this repository](https://github.com/microsoft-dx/csharp-fundamentals/) full with basic C# projects. If you want to go deeply into advanced C# topics, you can check out [this repository](https://github.com/microsoft-dx/advanced-csharp).

So there you have it, a well documented post about basic delegates, lambda delegates and asynchronous delegates. Stay tuned on this blog (and star the [microsoft-dx organization](https://github.com/microsoft-dx/)) to emerge in the beautiful world of “there’s an app for that”.
