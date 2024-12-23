using RecruitmentProject.Domain.Companies;

namespace RecruitmentProject.Domain.Candidates;

public class CandidateWorkflowStep
{
    private CandidateWorkflowStep(Guid? userId, Guid? roleId, int stepNumber, string description, Status status)
    {
        UserId = userId;
        RoleId = roleId;
        StepNumber = stepNumber;
        Description = description;
        Status = status;
    }

    public Guid? UserId { get; private set; }
    public Guid? RoleId { get; private set; }
    public int StepNumber { get; private set; }
    public string Description { get; private set; }
    public Status Status { get; private set; }
    public string? Feedback { get; private set; }

    public static CandidateWorkflowStep Create(Guid? userId, Guid? roleId, int stepNumber, string description)
    {
        ArgumentNullException.ThrowIfNull(stepNumber);
        ArgumentNullException.ThrowIfNull(description);
        
        return new CandidateWorkflowStep(userId, roleId, stepNumber, description, Status.InProcessing);
    }
    
    public void Approve(Employee employee, string feedback)
    {
        ArgumentNullException.ThrowIfNull(employee);
        ArgumentException.ThrowIfNullOrWhiteSpace(feedback);
        
        Status = Status.Approved;
        Feedback = feedback;
    }
    
    public void Reject(Employee employee, string feedback)
    {
        ArgumentNullException.ThrowIfNull(employee);
        ArgumentException.ThrowIfNullOrWhiteSpace(feedback);
        
        Status = Status.Rejected;
        Feedback = feedback;
    }
    
    public void Restart()
    {
        Status = Status.InProcessing;
        Feedback = null;
    }
}