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
    //new Organization
    //{
    //    Id = 4,
    //    Name ="D",
    //    ParentId = 1
    //},
     new Organization { Id = 5, Name ="AA"},
     new Organization { Id = 6, Name ="BB", ParentId = 5}
};

var obj = GetEmbeddedObjects(organizations);


static List<Organization> GetEmbeddedObjects(List<Organization> organizations)
{
    List<Organization> result = new();

    foreach (var item in organizations)
    {
        if (item.ParentId != null) continue;

        result.Add(item);

        organizations.Remove(item);

        result[^1].Organizations = GetChildren(item.Id, ref organizations);
    }

    return result;
}


static List<Organization> GetChildren(int Id, ref List<Organization> organizations)
{
    List<Organization> temp = new();

    foreach (var item in organizations)
    {
        if (item.ParentId == Id)
        {
            organizations.Remove(item);
            item.Organizations = GetChildren(item.Id, ref organizations);
            temp.Add(item);
        }
    }

    return temp;
}







/*
 * Organization embeddedObjects = new()
        {
            Id = item.Id,
            Name = item.Name,
            Organizations = GetChildren(item.Id, ref organizations)
        };

        result.Add(embeddedObjects);*/