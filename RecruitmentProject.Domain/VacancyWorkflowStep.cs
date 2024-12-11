
namespace RecruitmentProject.Domain;

public class VacancyWorkflowStep
{
    public Guid UserId { get; set;  }
    public Guid RoleId { get; set; }
    public string Description { get; set; }

    public CandidateWorkflowStep Create()
    {
        return new CandidateWorkflowStep
        {
            UserId = UserId,
            RoleId = RoleId,
            Description = Description,
            Status = Status.InProcessing
        };
    }
}