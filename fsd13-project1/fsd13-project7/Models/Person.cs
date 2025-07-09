using System;
using System.Collections.Generic;

namespace fsd13_project7.Models;

public partial class Person
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? Age { get; set; }

    public string? Telephone { get; set; }

    public Person(string? name, int? age, string? telephone)
    {
        Name = name;
        Age = age;
        Telephone = telephone;
    }
}
