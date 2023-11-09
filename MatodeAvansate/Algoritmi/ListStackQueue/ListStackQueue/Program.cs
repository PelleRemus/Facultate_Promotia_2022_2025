using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListStackQueue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //
            // Universal List
            //
            List<int> list = new List<int>();
            list.AddEnd(1);
            list.AddEnd(2);
            list.AddBeginning(3);
            Console.WriteLine(list);
            Console.WriteLine();

            Console.WriteLine(list.RemoveEnd());
            Console.WriteLine(list.RemoveBeginning());
            list.AddEnd(1);
            list.AddEnd(2);
            list.AddBeginning(3);

            Console.WriteLine(list);
            Console.WriteLine();
            list.RemoveAll(1);
            Console.WriteLine(list);
            Console.WriteLine();

            //
            // Ordered List
            //
            OrderedList orderedList = new OrderedList();
            orderedList.AddInOrder(15);
            orderedList.AddInOrder(6);
            orderedList.AddInOrder(8);
            orderedList.AddInOrder(1);
            orderedList.AddInOrder(29);
            orderedList.AddInOrder(17);
            orderedList.AddInOrder(12);
            Console.WriteLine(orderedList);
            Console.ReadKey();
        }
    }
}
