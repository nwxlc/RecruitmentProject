using AutoFixture;
using FluentAssertions;
using RecruitmentProject.Domain.Companies;

namespace RecruitmentProject.TestDomain;

public class CompanyTest
{
    private readonly Fixture _fixture;

    public CompanyTest()
    {
        _fixture = new Fixture();
    }
    
    [Fact]
    public void CreateCompany_ValidParameters_CompanyCreated()
    {
        // Arrange
        var name = "Microsoft";
        var description = "Some description";

        // Act
        var company = Company.Create(name, description);

        // Assertion
        company.Should().NotBeNull();
        company.Id.Should().NotBe(Guid.Empty);
        company.Name.Should().Be(name);
        company.Description.Should().Be(description);
    }
    
    [Fact]
    public void CreateCompany_WithEmptyName_ThrowsArgumentException()
    {
        // Arrange
        var name = "";
        var description = "Some description";

        // Act
        Action action = () => Company.Create(name, description);

        // Assertion
        action.Should().Throw<ArgumentException>();
    }
    
    
    [Fact]
    public void CreateCompany_WithEmptyDescription_ThrowsArgumentException()
    {
        // Arrange
        var name = "Microsoft";
        var description = "";

        // Act
        Action action = () => Company.Create(name, description);

        // Assertion
        action.Should().Throw<ArgumentException>();
    }
}