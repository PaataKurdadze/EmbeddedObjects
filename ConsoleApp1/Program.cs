// See https://aka.ms/new-console-template for more information
using ConsoleApp1;

Console.WriteLine("Hello, World!");
var organizations = new List<Organization>()
{
    new Organization
    {
        Id = 1,
        Name ="a",
    },
    new Organization
    {
        Id = 2,
        Name ="B",
        ParentId = 1,
    },
    new Organization
    {
        Id = 3,
        Name ="a",
        ParentId = 2,
    },
    new Organization
    {
        Id = 4,
        Name ="B",
        ParentId = 1,
    }
};
