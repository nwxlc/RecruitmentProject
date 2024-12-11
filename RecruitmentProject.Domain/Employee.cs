using System.Security.AccessControl;

namespace RecruitmentProject.Domain;

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
        ArgumentNullException.ThrowIfNull(name);

        return new Employee(new Guid(), name, companyId, roleId);
    }
}