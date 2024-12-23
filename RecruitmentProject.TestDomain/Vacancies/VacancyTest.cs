using AutoFixture;
using FluentAssertions;
using RecruitmentProject.Domain.Candidates;
using RecruitmentProject.Domain.Vacancies;

namespace RecruitmentProject.TestDomain.Vacancies;

public class VacancyTest
{
    private readonly Fixture _fixture;

    public VacancyTest()
    {
        _fixture = new Fixture();
    }

    [Fact]
    public void CreateVacancy_ValidParameters_VacancyCreated()
    {
        // Arrange
        var description = "Description";
        var vacancyWorkflow = _fixture.Create<VacancyWorkflow>();

        //Act
        var vacancy = Vacancy.Create(description, vacancyWorkflow);
        
        // Assert
        vacancy.Description.Should().Be(description);
        vacancy.Workflow.Should().Be(vacancyWorkflow);
    }
    
    [Fact]
    public void CreateVacancy_WithInvalidName_ArgumentException()
    {
        // Arrange
        var description = "";
        var vacancyWorkflow = _fixture.Create<VacancyWorkflow>();

        //Act
        Action action = () => Vacancy.Create(description, vacancyWorkflow);
        
        // Assert
        action.Should().Throw<ArgumentException>();
    }
    
    [Fact]
    public void CreateVacancy_WithInvalidWorkflow_ArgumentException()
    {
        // Arrange
        var description = "Description";

        //Act
        Action action = () => Vacancy.Create(description, null);
        
        // Assert
        action.Should().Throw<ArgumentNullException>();
    }
    
    [Fact]
    public void Vacancy_CreateCandidate_ShouldCreateCandidateWithCorrectParameters()
    {
        //Arrange
        var name = "Sample vacancy";
        var description = "Sample description";
        var steps = _fixture.CreateMany<VacancyWorkflowStep>();
        var workflow = VacancyWorkflow.Create(name, steps.ToList());
        var candidateDocument = _fixture.Create<CandidateDocument>(); 
        var referralId = Guid.NewGuid(); 

        var vacancy = Vacancy.Create(description, workflow); 

        //Act
        var candidate = vacancy.CreateCandidate(candidateDocument, referralId); 

        //Assert
        candidate.Should().NotBeNull();
        candidate.Id.Should().NotBe(Guid.Empty);
        candidate.Document.Should().Be(candidateDocument);
        candidate.ReferralId.Should().Be(referralId);
    }
}