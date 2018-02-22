using System;

namespace Delegates.Examples
{
    public class AnonymousMethods : ExampleBase
    {
        public override void Run()
        {
            Console.WriteLine("=== Anonymous Methods Example ===");

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

            Console.WriteLine();
        }
    }
}
