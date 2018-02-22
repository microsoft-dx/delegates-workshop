using System;

namespace Delegates.Examples
{
    public class LambdaDelegate : ExampleBase
    {
        public override void Run()
        {
            Console.WriteLine("=== Lambda Delegates Example ===");

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

            Console.WriteLine();
        }
    }
}
