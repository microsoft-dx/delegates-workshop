using System;
using System.Runtime.Remoting.Messaging;
using System.Threading;

namespace Delegates.Examples
{
    public class AsynchronousDelegates : ExampleBase
    {
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
    }
}
