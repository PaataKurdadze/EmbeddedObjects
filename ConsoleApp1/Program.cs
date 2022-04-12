using ConsoleApp1;

var organizations = new List<Organization>()
{
    new Organization{Id = 7, Name ="AB", ParentId = 1},
    new Organization
    {
        Id = 1,
        Name ="A"
    },
    new Organization
    {
        Id = 2,
        Name ="B",
        ParentId = 1
    },
    new Organization
    {
        Id = 3,
        Name ="C",
        ParentId = 2
    },
    new Organization
    {
        Id = 4,
        Name ="D",
        ParentId = 1
    },
     new Organization { Id = 5, Name ="AA"},
     new Organization { Id = 6, Name ="BB", ParentId = 5}
};


static List<Organization> GetEmbeddedObjects(List<Organization> organizations)
{
    List<Organization> result = new();

    foreach (var item in organizations)
    {
        if (item.ParentId != null) continue;

        Organization embeddedObjects = new()
        {
            Id = item.Id,
            Name = item.Name
        };

        organizations.RemoveAt(item.Id);

        embeddedObjects.Organizations = FindChildren(item.Id, ref organizations);
    }

    return null;
}


static List<Organization> FindChildren(int Id, ref List<Organization> organizations)
{
    List<Organization> temp = new();

    foreach (var item in organizations)
    {
        if (item.ParentId == Id)
        {
            organizations.RemoveAt(item.Id);
            item.Organizations = FindChildren(item.Id, ref organizations);
            temp.Add(item);
        }
    }

    return temp;
}