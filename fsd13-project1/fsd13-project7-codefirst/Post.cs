using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fsd13_project7_codefirst
{
    public class Post
    {
        public int Id { get; set; }

        public string Content { get; set; }
        public int BlogId { get; set; } // Required foreign key property
        public Blog Blog { get; set; } = null!; // Required reference navigation to principal
    }
}
