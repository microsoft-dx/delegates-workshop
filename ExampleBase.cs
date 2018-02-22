using System;

namespace Delegates
{
    public abstract class ExampleBase
    {
        public abstract void Run();

        protected enum Operation
        {
            Add = 0,
            Substract = 1,
            Multiply = 2,
            Divide = 3
        }

        protected delegate void ExecuteOperation(double x, double y);

        protected void DisplayResult(Operation operationType, double value)
        {
            var message = string.Format("For the {0} operation: {1}",
                operationType.ToString(), value);

            Console.WriteLine(message);
        }

        #region Operation implementation

        protected void AddOperation(double x, double y)
        {
            DisplayResult(Operation.Add, x + y);
        }

        protected void SubstractOperation(double x, double y)
        {
            DisplayResult(Operation.Substract, x - y);
        }

        protected void MultiplyOperation(double x, double y)
        {
            DisplayResult(Operation.Multiply, x * y);
        }

        protected void DivideOperation(double x, double y)
        {
            DisplayResult(Operation.Divide, x / y);
        }

        #endregion
    }
}
