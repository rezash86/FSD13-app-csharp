using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fsd13_project1
{
    public abstract class Employee
    {
        protected string Name { get; set; }

        private int Id { get; set; } //property as private you make it hidden from outside

        public Employee(string name, int id)
        {
            Name = name;
            Id = id;
        }

        //abstract methods to be implemented by subclasses
        public abstract void Work();

        //common method for all the employee
        public void ShowInfo()
        {
            Console.WriteLine($"Employee : Name : {Name} and ID: {Id}");
        }
    }

    //Developer class
    public class Developer : Employee
    {
        //we use capital for the properties
        public string ProgrammingLanguage { get; set; }
        public Developer(string name, int id, string language) : base(name, id) 
        {
             ProgrammingLanguage = language;
        }
        public override void Work()
        {
            Console.WriteLine($"{Name} is coding in {ProgrammingLanguage}");
        }
    }

    public class Manager : Employee
    {
        public int TeamSize { get; set; }
        public Manager(string name, int id, int teamSize) : base(name, id)
        {
            TeamSize = teamSize;
        }
        public override void Work()
        {
            Console.WriteLine($"{Name} is managing a team of {TeamSize} people");
        }
    }
}
