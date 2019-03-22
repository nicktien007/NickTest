using System;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;

namespace Nick.Test.Expression
{
    class Program
    {
        static void Main(string[] args)
        {
            //System.Linq.Expressions.Expression firstArg = System.Linq.Expressions.Expression.Constant(2);
            //System.Linq.Expressions.Expression secondArg = System.Linq.Expressions.Expression.Constant(3);
            //System.Linq.Expressions.Expression add=System.Linq.Expressions.Expression.Add(firstArg,secondArg);

            //Func<int> compiled = System.Linq.Expressions.Expression.Lambda<Func<int>>(add).Compile();


            //====================================================//

            //System.Linq.Expressions.Expression<Func<int>> result = () => 2 + 3;
            //Func<int> compiled = result.Compile();

            //====================================================//
            //Expression<Func<string, string, bool>> expression = (x, y) => x.StartsWith(y);
            //var compiled = expression.Compile();



            //Console.WriteLine(compiled("Aaa","g"));

            PrintConvertValue("aa",x=>x.Length);
        }

        static void PrintConvertValue<Tinput, TOutput>(Tinput input,Converter<Tinput,TOutput> converter)
        {
            Console.WriteLine(converter(input));
        }
    }
}
