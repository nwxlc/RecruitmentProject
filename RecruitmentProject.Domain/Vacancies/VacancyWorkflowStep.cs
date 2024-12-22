namespace RecruitmentProject.Domain;

public class VacancyWorkflowStep
{
    private VacancyWorkflowStep(Guid? userId, Guid? roleId, string description, int stepNumber)
    {
        UserId = userId;
        RoleId = roleId;
        Description = description;
        StepNumber = stepNumber;
    }
    
    public Guid? UserId { get; private set;  }
    public Guid? RoleId { get; private set; }
    public string Description { get; private set; }
    public int StepNumber { get; private set; }

    public static VacancyWorkflowStep Create(Guid? userId, Guid? roleId, string description, int stepNumber)
    {
        ArgumentNullException.ThrowIfNull(description);
        ArgumentNullException.ThrowIfNull(stepNumber);

        return new VacancyWorkflowStep(userId, roleId, description, stepNumber);
    }
    
    public CandidateWorkflowStep CreateCandidateWorkflowStep()
    {
        return CandidateWorkflowStep.Create(UserId,
            RoleId,
            StepNumber,
            Description);
    }
}