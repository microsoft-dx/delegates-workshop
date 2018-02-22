using Delegates.Examples;

namespace Delegates
{
    class Program
    {
        static void Main(string[] args)
        {
            var simple = new SimpleDelegates();
            var multiple = new MultipleDelegates();
            var anonymous = new AnonymousMethods();
            var lambda = new LambdaDelegate();
            var asynchronous = new AsynchronousDelegates();

            simple.Run();
            multiple.Run();
            anonymous.Run();
            lambda.Run();
            asynchronous.Run();
        }
    }
}
