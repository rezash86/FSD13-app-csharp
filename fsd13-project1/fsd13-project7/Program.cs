using fsd13_project7.Models;

namespace EntityFrameworkExamples
{
    class Program
    {
        public static void Main(string[] args)
        {
            CDbFsdTestMdfContext context = new CDbFsdTestMdfContext();
            context.People.Add(new Person("FSDDDDDDDD", 120, "sdd333333"));
            context.SaveChanges();
        }
    }
}
