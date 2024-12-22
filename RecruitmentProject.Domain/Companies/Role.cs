namespace RecruitmentProject.Domain;

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
        ArgumentNullException.ThrowIfNull(name);

        return new Role(new Guid(), name);
    }
}