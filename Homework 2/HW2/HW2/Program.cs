using System;

namespace HW2
{
    class Program
    {
        static void Main(string[] args)
        {

            OwnList<int> IntegerList = new OwnList<int>();
            IntegerList.Add(1);
            IntegerList.Add(2);
            IntegerList.Add(3);
            IntegerList.Add(4);
            IntegerList.Add(4);
            IntegerList.Add(5);
            IntegerList.Add(5);
            IntegerList.Add(6);
            IntegerList.Add(6);
            IntegerList.Remove(4);
            IntegerList.Remove(5);
            IntegerList.Remove(5);
            foreach (var item in IntegerList)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }
    }
}
