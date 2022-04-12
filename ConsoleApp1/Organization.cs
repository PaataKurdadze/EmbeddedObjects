namespace ConsoleApp1
{
    public class Organization
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public int? ParentId { get; set; }

        public List<Organization>? Organizations { get; set; }

    }
}
