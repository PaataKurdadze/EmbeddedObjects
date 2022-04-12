using ConsoleApp1;
using System.Text.Json;

var organizations = new List<Organization>
{
    new Organization {Id = 4, Name = "DD", ParentId = 1},
    new Organization {Id = 1, Name = "A"},
    new Organization {Id = 2, Name = "B", ParentId = 1},
    new Organization {Id = 3, Name = "C", ParentId = 2},
    new Organization {Id = 4, Name = "D", ParentId = 1},
    new Organization {Id = 5, Name = "AA"},
    new Organization {Id = 6, Name = "BB", ParentId = 5}
};

var obj = GetEmbeddedObjects(organizations);


var options = new JsonSerializerOptions { WriteIndented = true };
string jsonString = JsonSerializer.Serialize(obj, options);
Console.WriteLine(jsonString);
Console.ReadKey();


static IEnumerable<Organization> GetEmbeddedObjects(IList<Organization> organizations)
{
    List<Organization> result = new();

    for (var i = 0; i < organizations.Count; i++)
    {
        var item = organizations[i];
        if (item.ParentId != null) continue;

        result.Add(item);

        organizations.Remove(item);
        i = -1;

        result[^1].Organizations = GetChildren(item.Id, ref organizations);
    }

    return result;
}


static List<Organization> GetChildren(int Id, ref IList<Organization> organizations)
{
    List<Organization> temp = new();

    for (var i = 0; i < organizations.Count; i++)
    {
        var item = organizations[i];
        if (item.ParentId != Id) continue;

        organizations.Remove(item);
        i--; //i = -1;

        item.Organizations = GetChildren(item.Id, ref organizations);
        temp.Add(item);
    }

    return temp;
}
