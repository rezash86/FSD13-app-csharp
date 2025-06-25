using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fsd13_project1
{
    public class Animal
    {
        /*
         * private String name;
         * public String getName();
         * public void setName(String name){
         *      this.name = name;
         * }
         */ 
        protected string Name {  get; set; }
        public Animal(string name) {
            Name  = name;
        }

        //the name of the methods are in Capital
        public void Eat()
        {
            Console.WriteLine($"{Name} is Eating");
        }

        public virtual void Speak()
        {
            Console.WriteLine($"{Name} makes a sound");
        }

    }
}
