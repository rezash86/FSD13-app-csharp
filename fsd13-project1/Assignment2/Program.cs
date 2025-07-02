






namespace StudentGradeManagement
{
    public record Student(string Id, string Name, string Course, double Grade);
    class Program
    {
        static string filePath = @"../../../student.csv";
        static List<Student> students = new List<Student>();
        static void Main()
        {
            //LoadAll the studnets
            LoadAllStudents();


            while (true)
            {
                Console.WriteLine("\nStudent Grade Management");
                Console.WriteLine("1. View all students");
                Console.WriteLine("2. Filter by course");
                Console.WriteLine("3. Show top students (grade > 85)");
                Console.WriteLine("4. Average grade for a course");
                Console.WriteLine("5. Add new student");
                Console.WriteLine("6. Exit");
                Console.Write("Choose an option: ");
                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        //view the students
                        ViewAllStudents();
                        break;
                    case "2":
                        //filter by course
                        FilterByCourse();
                        break;
                    case "3":
                        //show top student
                        ShowTopStudents();
                        break;
                    case "4":
                        //calculate average
                        CalculateAverage();
                        break;
                    case "5":
                        //add a student
                        AddStudent();
                        break;
                    case "6":
                        //save students
                        SaveStudents();
                        return;
                    default:
                        Console.WriteLine("Invalid Choice");
                        break;

                }

            }
        }

        private static void CalculateAverage()
        {
            Console.Write("Enter course name:");
            var courseName = Console.ReadLine();
            var selected = students.Where(st => st.Course.Equals(courseName, StringComparison.OrdinalIgnoreCase)).ToList(); 
            //check if there is any student
            if (selected.Any())
            {
                var avg = selected.Average(s => s.Grade);
                Console.WriteLine($"Average grade for course {courseName} : {avg:F2}");
            }
            else
            {
                Console.WriteLine("No student found for this course");
            }
        }

        private static void ShowTopStudents()
        {
            //students with grade more than 85
            var results = students.Where(st => st.Grade > 85);
            foreach (var st in results)
            {
                Console.WriteLine($"{st.Id} : {st.Name} - {st.Course} -{st.Grade}");
            }
        }

        private static void FilterByCourse()
        {
            Console.Write("Enter a course name: ");
            var courseName = Console.ReadLine();
            var results = students.Where(std => std.Course.ToLower().Equals(courseName.ToLower())).ToList();
            foreach(var st in results)
            {
                Console.WriteLine($"{st.Id} : {st.Name} - {st.Course} -{st.Grade}");
            }
        }

        private static void ViewAllStudents()
        {
            foreach (Student student in students)
            {

                Console.WriteLine($"{student.Id},{student.Name},{student.Course},{student.Grade}");
            }
        }

        private static void AddStudent()
        {
            Console.Write("Enter ID:");
            var id = Console.ReadLine();
            Console.Write("Enter Name:");
            var name = Console.ReadLine();
            Console.Write("Enter Course:");
            var course = Console.ReadLine();
            Console.Write("Enter Grade:");
            
            //var grade = Console.ReadLine();
            //calling double.Parse() => it throws excetpion
            
            if(double.TryParse(Console.ReadLine(), out double grade)) //it there is no excetpion happens it returns true and the value of calling the method will reside in grade
            {
                students.Add(new Student(id, name, course, grade));
            }
            else // means parsing had error
            {
                Console.WriteLine("Invalid grade");
            }
        }

        private static void SaveStudents()
        {
            using var writer = new StreamWriter(filePath);
            writer.WriteLine("Id,Name,Course,Grade");
            foreach (var student in students)
            {
                writer.WriteLine($"{student.Id},{student.Name},{student.Course},{student.Grade}");
            }
        }

        private static void LoadAllStudents()
        {
            if (!File.Exists(filePath)) return; //because there is no data to load

            // we need to read the file
            var lines = File.ReadAllLines(filePath).Skip(1);
            foreach (var line in lines) { 
                //each record has data seperated by ,
                var parts = line.Split(',');
                if(parts.Length == 4 && double.TryParse(parts[3], out double grade))
                {
                    students.Add(new Student(parts[0], parts[1], parts[2], grade));
                }
            }
        }
    }
}