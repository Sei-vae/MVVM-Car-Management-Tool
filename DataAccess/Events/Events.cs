using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Events
{
    public class Events
    {
        public delegate void MyDelegate(string msg);

        // set target method
        MyDelegate del = new MyDelegate(MethodA);

        // or 

       // MyDelegate del = MethodA;

        // or set lambda expression 

       // MyDelegate del = (string msg) => Console.WriteLine(msg);

        // target method
        static void MethodA(string message)
        {
            Console.WriteLine(message);
        }

    }
}
