using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fsd13_projects8
{
    public class Car
    {
        public int Id{ get; set; }

        [Required]
        [StringLength(100)]
        public string MakeModel { get; set; }

        public int OwnerId { get; set; }

        public virtual Owner owner { get; set; }

        public override string ToString()
        {
            return $"{Id},{MakeModel}";
        }
    }
}
