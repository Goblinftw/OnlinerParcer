using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Parcer;

namespace OnlinerParcer
{
    class Program
    {
        private static void PrintToFile(List<Auto> autos)
        {
            using (var stream = File.CreateText(@"..\..\result.txt"))
            {
                foreach (var auto in autos)
                {
                    stream.WriteLine("Id: {0}, Name: {1}", auto.Id, auto.Name);
                    foreach (var phoneNumber in auto.PhoneNumbers)
                    {
                        stream.WriteLine(" Phone: {0}", phoneNumber);
                    }
                    stream.WriteLine();
                }
            }
            //foreach (var auto in autos)
            //{
            //    Console.WriteLine("Id: {0}, Name: {1}", auto.Id, auto.Name);
            //    foreach (var phoneNumber in auto.PhoneNumbers)
            //    {
            //        Console.WriteLine(" Phone: {0}", phoneNumber);
            //    }
            //    Console.WriteLine();
            //}
        }

        private static void Main(string[] args)
        {
            var parcer = new AutoBaraholkaParcer();
            var autos = parcer.Parce();
            PrintToFile(autos);
        }
    }
}
