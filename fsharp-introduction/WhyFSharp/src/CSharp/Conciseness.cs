using System;
using System.Linq;

namespace CSharp
{
    public static class Conciseness
    {
        public class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }

        public static void PrintPerson(Person person)
        {
            int age = person.Age;
            string name = person.Name;

            Console.WriteLine(String.Join(",", Enumerable.Range(0, age).Select(a => $"{name} -- {a}")));
        }
    }
}
