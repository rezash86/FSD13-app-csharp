using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fsd13_project7_codefirst
{
    public class Blog
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public ICollection<Post> Posts { get; } = new List<Post>(); // Collection navigation containing dependents
    }
}
