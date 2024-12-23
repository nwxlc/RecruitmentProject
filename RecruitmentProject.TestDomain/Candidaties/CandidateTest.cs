using AutoFixture;
using FluentAssertions;
using RecruitmentProject.Domain.Candidates;
using RecruitmentProject.Domain.Companies;

namespace RecruitmentProject.TestDomain.Candidaties;

public class CandidateTest
{
    private readonly Fixture _fixture;

    public CandidateTest()
    {
        _fixture = new Fixture();
    }

    [Fact]
    public void Create_ValidParameters_ReturnsCandidate()
    {
        var vacancyId = Guid.NewGuid();
        var referralId = Guid.NewGuid();
        var document = _fixture.Create<CandidateDocument>();
        var steps = _fixture.CreateMany<CandidateWorkflowStep>();
        var workflow = CandidateWorkflow.Create(steps.ToList());

        var candidate = Candidate.Create(vacancyId, referralId, workflow, document);

        candidate.Should().NotBeNull();
        candidate.Id.Should().NotBe(Guid.Empty);
        candidate.Document.Should().Be(document);
        candidate.ReferralId.Should().Be(referralId);
    }
    
    [Fact]
    public void Approve_Candidate_Succeeds()
    {
        // Arrange
        var candidate = _fixture.Create<Candidate>();
        var employee = _fixture.Create<Employee>();
        var feedback = "Feedback";
        var approvesCount = candidate.Workflow.Steps.Count(x => x.Status == Status.Approved);

        // Act
        candidate.Approve(employee, feedback);

        // Assert
        candidate.Workflow.Steps.Count(x => x.Status == Status.Approved).Should().NotBe(approvesCount);
        candidate.Workflow.Steps.Count(x => x.Status == Status.Approved).Should().Be(approvesCount + 1);
    }
    
    [Fact]
    public void Approve_CandidateWithInvalidEmployee_ThrowsArgumentNullException()
    {
        // Arrange
        var candidate = _fixture.Create<Candidate>();
        var feedback = "Feedback";

        // Act
        Action action = () => candidate.Approve(null, feedback);

        // Assert
        action.Should().Throw<ArgumentNullException>();
    }
    
    [Fact]
    public void Approve_CandidateWithInvalidFeedback_ThrowsArgumentException()
    {
        // Arrange
        var candidate = _fixture.Create<Candidate>();
        var employee = _fixture.Create<Employee>();
        var feedback = "";

        // Act
        Action action = () => candidate.Approve(employee, feedback);

        // Assert
        action.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void Reject_Candidate_Succeeds()
    {
        // Arrange
        var candidate = _fixture.Create<Candidate>();
        var employee = _fixture.Create<Employee>();
        var feedback = "Feedback";
        var rejectsCount = candidate.Workflow.Steps.Count(x => x.Status == Status.Rejected);

        // Act
        candidate.Reject(employee, feedback);

        // Assert
        candidate.Workflow.Steps.Count(x => x.Status == Status.Rejected).Should().Be(rejectsCount + 1);
    }
}