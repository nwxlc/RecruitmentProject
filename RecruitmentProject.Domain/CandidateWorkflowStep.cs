namespace RecruitmentProject.Domain;

public class CandidateWorkflowStep
{
    public Guid UserId { get; set; }
    public Guid RoleId { get; set; }
    public string Description { get; set; }
    public Status Status { get; set; }
    public string Feedback { get; private set; }

    public void SetFeedback(string feedback)
    {
        Feedback = feedback;
    }
    
    public void Approve(Guid userId, string feedback)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(feedback);
        
        Status = Status.Approved;
        SetFeedback(feedback);
    }
    
    public void Reject(Guid userId, string feedback)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(feedback);
        
        Status = Status.Rejected;
        SetFeedback(feedback);
    }
    
    public void Restart()
    {
        Status = Status.InProcessing;
    }
}