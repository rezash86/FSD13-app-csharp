using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace fsd13_project2
{
    internal class LinqExamples
    {
        static void Main(string[] args)
        {
            List<int> numbers = new() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            //Method syntax
            var enenNumbers = numbers.Where(n => n % 2 == 0).ToList(); //Filter
            Console.WriteLine("Even numbers " + string.Join(", ", enenNumbers));
            //Query syntax
            var evenQuery = (from n in numbers where n % 2 == 0 select n).ToList();
            Console.WriteLine("Even numbers " + string.Join(", ", evenQuery));

            //select and transform
            var squares = numbers.Select(n => n * n).ToList(); //MAP
            Console.WriteLine(string.Join(", ", squares));

            //Filtering and Ordering
            var filtered = numbers.Where(n => n > 5).OrderBy(n => n).ToList();
            Console.WriteLine("Numbers > 5 :" + string.Join(",", filtered));

            //Working with objects
            var poeple = new List<Person>
            {
                new Person {Name ="Alice", Age = 30},
                new Person {Name ="Bob", Age = 25},
                new Person {Name ="Charlie", Age = 25},
                new Person {Name ="Diana", Age = 30}
            };

            var names = poeple.Select(p => p.Name);
            Console.WriteLine("Names : " + string.Join(",", names));

            var groupedByAge = poeple.GroupBy(p=> p.Age);
            foreach(var group in groupedByAge)
            {
                Console.WriteLine($"People aged {group.Key}");
                foreach(var person in group) 
                    Console.WriteLine($" - {person.Name}");
            }

            //Aggregation
            var averageAge = poeple.Average(p => p.Age);
            Console.WriteLine($"The average age : {averageAge}");

            //Any, All
            Console.WriteLine("All over 20 ? " + poeple.All(p => p.Age > 20));
            Console.WriteLine("Any under 20 ? " + poeple.All(p => p.Age < 20));

        }
    }

    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
