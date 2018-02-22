using System;

namespace Delegates.Examples
{
    public class SimpleDelegates : ExampleBase
    {
        public override void Run()
        {
            Console.WriteLine("=== Simple Delegates Example ===");

            var addOperation = new ExecuteOperation(AddOperation);
            var substractOperation = new ExecuteOperation(SubstractOperation);
            var multiplyOperation = new ExecuteOperation(MultiplyOperation);
            var divideOperation = new ExecuteOperation(DivideOperation);

            addOperation(2, 3);
            substractOperation(5, 3);
            multiplyOperation(10, 2);
            divideOperation(20, 4);

            Console.WriteLine();
        }
    }
}
