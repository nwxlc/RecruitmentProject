using AutoFixture;
using FluentAssertions;
using RecruitmentProject.Domain.Companies;

namespace RecruitmentProject.TestDomain;

public class EmployeeTest
{
    private readonly Fixture _fixture;

    public EmployeeTest()
    {
        _fixture = new Fixture();
    }
    
    [Fact]
    public void CreateEmployee_ValidParameters_EmployeeCreated()
    {
        // Arrange
        var roleId = Guid.NewGuid();
        var name = "John Doe";
        var companyId = Guid.NewGuid();

        // Act
        var employee = Employee.Create(name, companyId, roleId);

        // Assertion
        employee.Should().NotBeNull();
        employee.Id.Should().NotBe(Guid.Empty);
        employee.RoleId.Should().Be(roleId);
        employee.Name.Should().Be(name);
        employee.CompanyId.Should().Be(companyId);
    }
    
    [Fact]
    public void CreateEmployee_WithInvalidName_ThrowsArgumentException()
    {
        // Arrange
        var roleId = Guid.NewGuid();
        var name = "";
        var companyId = Guid.NewGuid();

        // Act
        Action action = () => Employee.Create(name, companyId, roleId);

        // Assert
        action.Should().Throw<ArgumentException>();
    }
    
    [Fact]
    public void CreateEmployee_WithEmptyRoleId_ThrowsArgumentException()
    {
        // Arrange
        var emptyRoleId = Guid.Empty;
        var name = "John Doe";
        var companyId = Guid.NewGuid();

        // Act
        Action action = () => Employee.Create(name, companyId, emptyRoleId);

        // Assert
        action.Should().Throw<ArgumentException>();
    }
    
    [Fact]
    public void CreateEmployee_WithEmptyCompanyId_ThrowsArgumentException()
    {
        // Arrange
        var roleId = Guid.NewGuid();
        var name = "John Doe";
        var emptyCompanyId = Guid.Empty;

        // Act
        Action action = () => Employee.Create(name, emptyCompanyId, roleId);

        // Assert
        action.Should().Throw<ArgumentException>();
    }
}