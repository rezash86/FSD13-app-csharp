using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fsd13_project7_codefirst
{
    public class Address
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }

        //add foreign key
        public int EmployeeId { get; set; }

        public Employee Employee { get; set; }

        public Address(string city, string postalCode)
        {
            City = city;
            PostalCode = postalCode;
        }
    }
}
