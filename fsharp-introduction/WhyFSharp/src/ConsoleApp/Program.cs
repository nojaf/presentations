using CSharp;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Conciseness.PrintPerson(new Conciseness.Person { Age = 5, Name = "Frederick"});
            FSharp.Conciseness.printPerson(new FSharp.Conciseness.Person("Frederick", 5));
            
//            FSharp.Correctness.printAddress(new FSharp.Correctness.Address("Forest Avenue", "San Francisco", "10000"));
//
//            FSharp.Correctness.compareNames(new FSharp.Correctness.PersonalName("John", "Doe"),
//                new FSharp.Correctness.PersonalName("Jane", "Doe"));
        }
    }
}