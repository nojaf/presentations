using System;
using WhyFSharp;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Correctness.printAddress(new Correctness.Address("Forest Avenue", "San Francisco", "10000"));

            Correctness.compareNames(new Correctness.PersonalName("John", "Doe"),
                new Correctness.PersonalName("Jane", "Doe"));
        }
    }
}
