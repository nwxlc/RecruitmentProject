namespace RecruitmentProject.Domain;

public class Vacancy
{
    public Guid Id { get; set; }
    public string Description { get; set; }
    public VacancyWorkflow Workflow { get; set; }

    public Candidate Create(CandidateDocument document, Guid? referralId)
    {
        return new Candidate
        {
            Id = Guid.NewGuid(),
            VacancyId = Id,
            ReferralId = referralId,
            Workflow = Workflow.Create(),
            Document = document
        };
    }
}