using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numArray = { 34, 6, 2, 98, 1, 43, 20, 58, 90 };
            //var query1 = from i in numArray
            //            where i % 2 == 0
            //            select i;
            //var query2 = numArray.Where(i => i % 2 == 0).OrderBy(i => i);
            //foreach (var item in query2)
            //{
            //    Console.WriteLine(item.ToString());
            //}
            string[] strArray = { "abc", "aaa", "bde", "bade", "xyz" };
            var query3 = from s in strArray
                         where s.Contains("a")
                         select s;
            var query4 = strArray.Where(s => s.Contains("a")).FirstOrDefault();
            foreach (var item in query4)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }
    }
}
