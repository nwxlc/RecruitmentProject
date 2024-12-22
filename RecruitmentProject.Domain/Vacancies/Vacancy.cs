namespace RecruitmentProject.Domain;

public class Vacancy
{
    private Vacancy(Guid id, string description, VacancyWorkflow workflow)
    {
        Id = id;
        Description = description;
        Workflow = workflow;
    }

    public Guid Id { get; private set; }
    public string Description { get; private set; }
    public VacancyWorkflow Workflow { get; private set; }

    public static Vacancy Create(Guid id, string description, VacancyWorkflow vacancyWorkflow)
    {
        ArgumentNullException.ThrowIfNull(description);

        return new Vacancy(id, description, vacancyWorkflow);
    }
    
    public Candidate CreateCandidate(CandidateDocument document, Guid? referralId)
    {
        return Candidate.Create(Id, referralId, Workflow.CreateCandidateWorkflow(), document);
    }
}