using System;
namespace vscode
{
    public static class Ch3
    {
        public static void Run()
        {
            ExpressionBodied();
            ExpressionBodiedWithParm(44);
        }

        public static void ExpressionBodied() => 
            Console.WriteLine("Here is an example of an Expression Bodied Method.");
        public static void ExpressionBodiedWithParm(int z) =>
            Console.WriteLine("Here is an expression bodied method. Note only one statement: {0}", z);
    }
}