
using fsd13_project7_codefirst;

namespace EntityFrameworkExamples
{
    class Program
    {
        public static void Main(string[] args)
        {
            MyDbcontext myDbcontext  = new MyDbcontext();


            var employee = new Employee("c", 20, "99999", "ggg@fff.c");
            employee.addresses.Add(new Address("Mon", "HHHH"));
            employee.addresses.Add(new Address("TOR", "BBBBB"));

            myDbcontext.Employees.Add(employee);
            myDbcontext.SaveChanges();

            var blog = new Blog { Title = "my title" };
            blog.Posts.Add(new Post { Content = "content1" });
            blog.Posts.Add(new Post { Content = "content12" });

            myDbcontext.Blogs.Add(blog);
            myDbcontext.SaveChanges();

        }
    }
}