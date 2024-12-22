using RecruitmentProject.Domain.Companies;

namespace RecruitmentProject.Domain.Candidates;

public class CandidateWorkflow
{
    private CandidateWorkflow(Status status, 
        IReadOnlyCollection<CandidateWorkflowStep> steps)
    {
        Status = status;
        Steps = steps;
    }

    public Status Status { get; private set; }
    public string Feedback { get; private set; }
    public IReadOnlyCollection<CandidateWorkflowStep> Steps { get; private set; }

    public static CandidateWorkflow Create(IReadOnlyCollection<CandidateWorkflowStep> steps)
    {
        return new CandidateWorkflow(Status.InProcessing, steps);
    }
    
    public void Approve(Employee employee, string feedback)
    {
        ArgumentNullException.ThrowIfNull(employee);
        ArgumentException.ThrowIfNullOrWhiteSpace(feedback);

        var step = Steps
            .Where(step => step.Status == Status.InProcessing)
            .OrderBy(step => step.StepNumber)
            .First();
        
        step.Approve(employee, feedback);
    }

    public void Reject(Employee employee, string feedback)
    {
        ArgumentNullException.ThrowIfNull(employee);
        ArgumentException.ThrowIfNullOrWhiteSpace(feedback);
        
        var step = Steps
            .Where(step => step.Status == Status.InProcessing)
            .OrderBy(step => step.StepNumber)
            .First();
        
        step.Reject(employee, feedback);
    }
    
    public void Restart()
    {
        foreach (var step in Steps)
        {
            step.Restart();
        }
        Status = Status.Restarted;
    }
}