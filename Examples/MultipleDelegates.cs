using System;

namespace Delegates.Examples
{
    public class MultipleDelegates : ExampleBase
    {
        public override void Run()
        {
            Console.WriteLine("=== Multiple Delegates Example ===");

            ExecuteOperation mathOperations = null;

            mathOperations += new ExecuteOperation(AddOperation);
            mathOperations += new ExecuteOperation(SubstractOperation);
            mathOperations += new ExecuteOperation(MultiplyOperation);
            mathOperations += new ExecuteOperation(DivideOperation);

            mathOperations(40, 5);

            Console.WriteLine();
        }
    }
}
