namespace RecruitmentProject.Domain;

public class Company
{
    private Company(Guid id, string name, string description)
    {
        Id = id;
        SetName(name);
        SetDescription(description);
    }

    public Guid Id { get; private init; }
    public string Name { get; private set; }
    public string Description { get; private set; }

    public static Company Create(string name, string description)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        ArgumentException.ThrowIfNullOrWhiteSpace(description);

        var company = new Company(new Guid(), name, description);

        return company;
    }

    public void SetName(string name)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        Name = name;
    }
    
    public void SetDescription(string description)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(description);
        Description = description;
    }
}