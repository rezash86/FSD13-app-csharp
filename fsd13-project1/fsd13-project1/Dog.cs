using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fsd13_project1
{
    internal class Dog : Animal
    {
        public string Breed { get; set; }
        public Dog(string name, string breed) : base(name) { 
            Breed = breed;
        }

        public override void Speak()
        {
            base.Speak(); //super.Speak() in java
            Console.WriteLine($"{Name}: {Breed} Barks");
        }
    }
}
