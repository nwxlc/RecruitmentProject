using AutoFixture;
using FluentAssertions;
using RecruitmentProject.Domain.Companies;

namespace RecruitmentProject.TestDomain;

public class RoleTest
{
    private readonly Fixture _fixture;

    public RoleTest()
    {
        _fixture = new Fixture();
    }
    
    [Fact]
    public void CreateRole_ValidParameters_RoleCreated()
    {
        // Arrange
        var name = "Admin";

        // Act
        var role = Role.Create(name);

        // Assertion
        role.Should().NotBeNull();
        role.Id.Should().NotBe(Guid.Empty);
        role.Name.Should().Be(name);
    }
    
    [Fact]
    public void CreateRole_WithInvalidName_ThrowsArgumentException()
    {
        // Arrange
        var name = "";

        // Act
        Action action = () => Role.Create(name);

        // Assertion
        action.Should().Throw<ArgumentException>();
    }
}