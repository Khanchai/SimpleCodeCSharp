using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace SimpleCodeCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree();

//            PrintLinq();
//            Console.WriteLine("+++++++ Select ++++++++");
//            PrintSelect();
//            Console.WriteLine("+++++++ PrintOftype ++++++++");
//            PrintOftype();
//            Console.WriteLine("+++++++ PrintWhereFunction ++++++++");
//            PrintWhereFunction();
//            Console.WriteLine("+++++++ Cast ++++++++");
//            PrintCast();
            Console.ReadKey();
        }
        public static void PrintLinq()
        {
            //var listNumber = new List<int>() {  10 };
            var listNumber = new List<int>() { 5, 4, 50, 99, 3, 10, 18, 24, 28, 36, 38, 47, 49, 50, 70, 88, 99, 2, 6, 7, 10 };
            IEnumerable<int> query = from x in listNumber
                                     where x <= 10
                                     select x;
            foreach (var i in query)
            {
                Console.WriteLine(i);
            }
            //take first index from list
            var firstNumber = listNumber.Take(5);
            Console.WriteLine("++++++++ Take +++++++");
            foreach (var i in firstNumber)
            {
                Console.WriteLine(i);
            }
            //skip index from list
            var skipNumber = listNumber.Skip(7);
            Console.WriteLine("++++++++ Skip +++++++");
            foreach (var i in skipNumber)
            {
                Console.WriteLine(i);
            }
            //takewhile
            var takeWhileNumber = listNumber.TakeWhile((x, index) => x >= index);
            Console.WriteLine("++++++++ TakeWhile +++++++");
            foreach (var i in takeWhileNumber)
            {
                Console.WriteLine(i);
            }
            //skipwhile
            var skipWhileNumber = listNumber.SkipWhile(x => x <= 50);
            Console.WriteLine("++++++++ SkipWhile +++++++");
            foreach (var i in skipWhileNumber)
            {
                Console.WriteLine(i);
            }
            //count number
            Console.WriteLine("++++++++ Count +++++++");
            var countNumber = listNumber.Count();
            Console.WriteLine(countNumber);
            //sum number
            Console.WriteLine("++++++++ Sum +++++++");
            var sumNumber = listNumber.Sum();
            Console.WriteLine(sumNumber);
            //min number
            Console.WriteLine("++++++++ Min +++++++");
            var minNumber = listNumber.Min();
            Console.WriteLine(minNumber);
            //max number
            Console.WriteLine("++++++++ Max +++++++");
            var maxNumber = listNumber.Max();
            Console.WriteLine(maxNumber);
            //all
            Console.WriteLine("++++++++ All +++++++");
            var allNumber1 = listNumber.All(x => x >= 50);
            var allNumber2 = listNumber.All(x => x < 800);
            Console.WriteLine(allNumber1 + " <--- more than 50");
            Console.WriteLine(allNumber2 + " <--- less than 800");
            //any 
            Console.WriteLine("++++++++ Any +++++++");
            var anyNumber1 = listNumber.Any(x => x % 3 == 0);
            var anyNumber2 = listNumber.Any(x => x > 50);
            var anyNumber3 = listNumber.Any(x => x < 50);
            Console.WriteLine(anyNumber1);
            Console.WriteLine(anyNumber2);
            Console.WriteLine(anyNumber3);
        }
        public static void PrintSelect()
        {
            var listAnimals = new List<string>() { "ant", "bird", "cat", "dog" };
            var selectStringEqual = listAnimals.Select(x => x == "cat");
            var selectStringUpper = listAnimals.Select(x => x.ToUpper());
            foreach (var i in selectStringEqual)
            {
                Console.WriteLine(i);
            }
            foreach (var i in selectStringUpper)
            {
                Console.WriteLine(i);
            }
        }
        public static void PrintOftype()
        {
            var arr = new object[5];
            arr[0] = new StringBuilder();
            arr[1] = "string";
            arr[2] = "integer";
            arr[3] = new int[1];
            arr[4] = new double[3];
     
            var arrayList = new ArrayList {new StringBuilder(), "string1", "string2", new int[1], 1, 2, 3.1};

            var ofTypeArr = arrayList.OfType<double>();
            foreach (var i in ofTypeArr) 
            {
                Console.WriteLine("{0:0.0}",i);
            }
        }
        public static void PrintWhereFunction() 
        {
            var listString = new List<string>() { "ant","bird","cat","dog","cat",null,null,"zero","one","Orange" };
            var whereString = listString.Where(x => (x != null && x.ToLower().Contains("o")));
            foreach(var i in whereString){
                Console.WriteLine(i);
            }
        }

        public static void PrintCast()
        {
            var x = "string";
            var y = "3.2";
            var convert1 = x.Cast<char>();
            var convert2 = y.Cast<int>(); 
            Console.WriteLine(convert1);
            var i = convert2;
            Console.WriteLine(i);
        }

        public static void BinaryTree()
        {
            // Creating a parameter expression.
            ParameterExpression value = Expression.Parameter(typeof(int), "value");

            // Creating an expression to hold a local variable. 
            ParameterExpression result = Expression.Parameter(typeof(int), "result");

            // Creating a label to jump to from a loop.
            LabelTarget label = Expression.Label(typeof(int));

            // Creating a method body.
            BlockExpression block = Expression.Block(
                // Adding a local variable. 
                new[] { result },
                // Assigning a constant to a local variable: result = 1
                Expression.Assign(result, Expression.Constant(1)),
                // Adding a loop.
                    Expression.Loop(
                // Adding a conditional block into the loop.
                       Expression.IfThenElse(
                // Condition: value > 1
                           Expression.GreaterThan(value, Expression.Constant(1)),
                // If true: result *= value --
                           Expression.MultiplyAssign(result,
                               Expression.PostDecrementAssign(value)),
                // If false, exit the loop and go to the label.
                           Expression.Break(label, result)
                       ),
                // Label to jump to.
                   label
                )
            );

            // Compile and execute an expression tree. 
            int factorial = Expression.Lambda<Func<int, int>>(block, value).Compile()(5);

            Console.WriteLine(factorial);
            // Prints 120.

        }

    }
}
