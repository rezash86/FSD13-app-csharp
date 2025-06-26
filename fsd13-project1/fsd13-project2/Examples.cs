using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fsd13_project2
{
    internal class Examples
    {
        void Main(string[] args)
        {
            //dynamic
            dynamic value = "hello";
            Console.WriteLine(value.Length); //OK

            value = 123;
           // Console.WriteLine(value.Length); //OK at compile but not ok at runtime

            value = new { Name = "Phil" }; // OK it is an object
            Console.WriteLine(value.Name);


            //record
            Friend friend1 = new Friend("Ali"); // friend1 will have an address in heap XXXXXXX
            Friend friend2 = new Friend("Ali"); // friend2 will have an address in heap YYYYYYY

            Console.WriteLine(friend1 == friend2 ); //2 objects are being compared by reference

            MyFriend myFriend1 = new MyFriend("Reza");
            MyFriend myFriend2 = new MyFriend("Reza");

            //myFriend1.name = "aaa"; //this cannnot happen because records are immutable

            Console.WriteLine(myFriend1 == myFriend2); // True because records are by value

            //File
            string folderPath = "sampleFolder";
            string filePath = Path.Combine(folderPath, "sample.txt");

            //create the directory if it does not exist
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
                Console.WriteLine("Directory created");
            }

            //Write text to a file
            File.WriteAllText(filePath, "This is a sample text");
            Console.WriteLine("text written to the file");

            //read text from the file
            string readText = File.ReadAllText(filePath);
            Console.WriteLine("read from file:  " + readText);

            //Append a text to a file
            File.AppendAllText(filePath, "\nAppending to the existing file");
            Console.WriteLine("Appended to the existing file");

            //Read the file line by line
            //use streamReader
            using (StreamReader reader = new StreamReader(filePath))
            {
                string? line;
                while ((line = reader.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }

            //Get the file information
            FileInfo fileInfo = new FileInfo(filePath);
            Console.WriteLine($"\nfile Info : Name = {fileInfo.Name}, Size={fileInfo.Length} bytes, Create={fileInfo.CreationTime}");
            
            //Delete the file and Folder
            File.Delete(filePath);
            Directory.Delete(folderPath);
            Console.WriteLine("\n File and Directory deleted");

            Console.ReadKey(); //adding this line helps you to run the exe file and see the result in the screen
            
        }


       
    }

    class Friend
    {
        public string Name { get; set; }
        public Friend(string name)
        {
            Name = name;
        }
    }

    public record MyFriend(string name);
}
