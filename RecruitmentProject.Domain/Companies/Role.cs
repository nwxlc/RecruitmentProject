namespace RecruitmentProject.Domain.Companies;

public class Role
{
    private Role(Guid id, string name)
    {
        Id = id;
        Name = name;
    }

    public Guid Id { get; private init; }
    public string Name { get; private set; }

    public static Role Create(string name)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);

        return new Role(Guid.NewGuid(), name);
    }
}