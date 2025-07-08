using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDatabaseConnect
{
    internal class EnFrExample
    {
        static void Main(String[] args)
        {
            var context = new MyDbContext();
            context.People.Add(new Person { Name = "Reza", Age = 20, Telephone = "3333-333" });

            context.SaveChanges();

            var people = context.People.ToList();
            foreach (var person in people)
            {
                Console.WriteLine($"{person.Name} and {person.Age} : {person.Telephone}");
            }

            var fetched = context.People.Where(p => p.Name.Equals("Reza")).First();
        }   

    }
}
