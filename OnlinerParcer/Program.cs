using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Parcer;

namespace OnlinerParcer
{
    class Program
    {

        private static void Main(string[] args)
        {
            Console.WriteLine("Thread:{0}", Thread.CurrentThread.ManagedThreadId);
            var parcer = new AutoBaraholkaParcer();
            var autos = parcer.Parce();
            foreach (var auto in autos)
            {
                Console.WriteLine("Id: {0}, Name: {1}", auto.Id, auto.Name);
                foreach (var phoneNumber in auto.PhoneNumbers)
                {
                    Console.WriteLine(" Phone: {0}", phoneNumber);
                }
                Console.WriteLine();
            }
        }
    }
}
