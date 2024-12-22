namespace RecruitmentProject.Domain.Companies;

public class Employee
{
    private Employee(Guid id, string name, Guid companyId, Guid roleId)
    {
        Id = id;
        Name = name;
        CompanyId = companyId;
        RoleId = roleId;
    }

    public Guid Id { get; private init; }
    public string Name { get; private set; }
    public Guid CompanyId { get; private set; }
    public Guid RoleId { get; private set; }

    public static Employee Create(string name, Guid companyId, Guid roleId)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        ArgumentNullException.ThrowIfNull(companyId);
        ArgumentNullException.ThrowIfNull(roleId);
        
        if (companyId == Guid.Empty)
        {
            throw new ArgumentException("CompanyId cannot be empty", nameof(companyId));
        }
        
        if (roleId == Guid.Empty)
        {
            throw new ArgumentException("RoleId cannot be empty", nameof(roleId));
        }

        return new Employee(Guid.NewGuid(), name, companyId, roleId);
    }
}