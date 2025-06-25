using System;

namespace fsd13_project1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("== C# Basic examples");

            //variables and Types
            int number = 43;
            string message = "Hello, c#";
            bool isActive = true;
            double pi = 3.14159;

            Console.WriteLine($"Int : {number}, String: {message} , Bool : {isActive} , Double: {pi}");

            dynamic dyn = "Hello"; //skips compile-time check
            object obj = "Hello"; //base type of all types
            
            int? count = null; // nullable
            //int count2 = null;// it does not let you to have null for int

            Animal dog = new Animal("Dog");
            dog.Eat();
            


            //inhertance
            Dog myDog = new Dog("Buddy", "Golden retriever");
            myDog.Eat(); // Inherited from Animal;
            myDog.Speak(); // Overriden in Dog
            

            Console.WriteLine($"my dog breed : {myDog.Breed}"); //it should not if we want to hide this property

            //Reading value from the user
            Console.WriteLine("Enter your name");
            var nameInput =Console.ReadLine(); //We can get value from the user
            Console.WriteLine($"The user entered {nameInput}");
            
            //IF-Else
            if( nameInput != null  && nameInput.StartsWith("R"))
            {
                Console.WriteLine($"{nameInput} starts with R");
            }
            else
            {
                Console.WriteLine($"{nameInput} does not start with R");
            }

            //LOOP
            for (int i = 0; i < number; i++)
            {
                Console.Write("*");
            }
            // Array
            string[] colors = { "Red", "Green", "Blue" };
            //Loop
            foreach (string color in colors)
            {
                Console.WriteLine(color);
            }

            //calling method
            var sum = add(6, 9); //method by reference and not by value

            //Exception handling
            try
            {
                var result = colors[6];
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }

            //List
            List<int> numbers = new List<int>();
            numbers.Add(1);
            numbers.Add(2); //Generic

            //LOOP
            for(int n  = 0; n < numbers.Count; n++)
            {

            }

            foreach(int n in numbers)
            {

            }

            //LINQ
            numbers.ForEach(n => Console.WriteLine(n));


            //inheritance
            List<Employee> employees = new List<Employee>()
            {
                new Developer("Alice", 1, "C#"),
                new Manager("Bob", 102, 5),
                new Developer("Charlie", 103, "Java")
            };

            foreach(var employee in employees)
            {
                //employee.Id = 2; this is wrong
               
                employee.ShowInfo(); //abstraction and encapsulation 
                //protected for name and private for id
                employee.Work(); //Polymorphism
                Console.WriteLine();
               
            }

            //encapsulation
            BankAccount account = new BankAccount("Alice", 1000);
            account.Deposit(200);
            bool success = account.Withdrow(150);

            Console.WriteLine($"Balance will be {account.Balance}");
            //account.balance = 800; not allowed (private field)
            
        }

        static int add(int x, int y)
        {
            return x + y;
        }
    }
}