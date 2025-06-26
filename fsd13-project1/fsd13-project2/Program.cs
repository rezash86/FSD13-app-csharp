using System;
using System.Collections.Generic;
using System.Globalization;

namespace ExpenseTracker
{
    class Program
    {
        void Main(string[] args)
        {
            List<Expense> expenses = new List<Expense>();
            Console.WriteLine("Welcome to the Expense Tracker!");

            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\n1. Add Expense");
                Console.WriteLine("2. List Expenses");
                Console.WriteLine("3. Show Total");
                Console.WriteLine("4. Exit");
                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        try
                        {
                            Console.Write("Date (yyyy-MM-dd): ");
                            string dateInput = Console.ReadLine();
                            var date = DateTime.ParseExact(dateInput, "yyyy-MM-dd", CultureInfo.InvariantCulture);

                            Console.Write("Category : ");
                            var category = Console.ReadLine();

                            Console.Write("Amount :");
                            var amount = decimal.Parse(Console.ReadLine());

                            Console.Write("Description : ");
                            var description = Console.ReadLine();

                            expenses.Add(new Expense
                            {
                                Date = date,
                                Category = category,
                                Amount = amount,
                                Description = description
                            });

                            Console.WriteLine("Expense added");
                        }
                        catch(FormatException exc)
                        {
                            Console.WriteLine("Invalid date or amount format");
                        }
                        break;
                    case "2":
                        if (expenses.Count == 0)
                        {
                            Console.WriteLine("No expense recorded");
                        }
                        else
                        {
                            Console.WriteLine("Date       | category   | Amount    | Description");
                            Console.WriteLine("-----------|------------|---------- | ------------");
                            foreach(var e in expenses)
                            {
                                Console.WriteLine(e);
                            }
                        }
                            break;
                    case "3":
                        decimal total = 0;
                        foreach (var expense in expenses)
                        {
                            total += expense.Amount;
                        }
                        Console.WriteLine($"Total Spent : {total}");
                        break;
                    case "4":
                        exit = true;
                        Console.WriteLine("Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Invalid input.");
                        break;
                }
            }
        }
    }

    // TODO: Define Expense class with Date, Category, Amount, Description
    class Expense
    {
        public DateTime Date { get; set; }
        public string Category { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }

        public override string ToString()
        {
            return $"{Date:yyyy-MM-dd} | {Category,-10} | {Amount,8:C} | {Description}";
        }
    }
}
