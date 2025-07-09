using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fsd13_project7_codefirst
{
    public class Employee
    {
        public int Id { get; set; } // EF will auto-increment this
        public string Name { get; set; }
        public int? Age { get; set; }
        public string Telephone { get; set; }

        public string Email { get; set; }

        public List<Address> addresses { get; set; } = new();    

        public Employee(string? name, int? age, string? telephone, string email)
        {
            Name = name;
            Age = age;
            Telephone = telephone;
            Email = email;
        }
    }
}
