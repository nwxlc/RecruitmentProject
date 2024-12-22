using RecruitmentProject.Domain.Candidates;

namespace RecruitmentProject.Domain.Vacancies;

public class Vacancy
{
    private Vacancy(Guid id, string description, VacancyWorkflow workflow)
    {
        Id = id;
        Description = description;
        Workflow = workflow;
    }

    public Guid Id { get; private init; }
    public string Description { get; private set; }
    public VacancyWorkflow Workflow { get; private set; }

    public static Vacancy Create(string description, VacancyWorkflow vacancyWorkflow)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(description);
        ArgumentNullException.ThrowIfNull(vacancyWorkflow);

        return new Vacancy(Guid.NewGuid(), description, vacancyWorkflow);
    }
    
    public Candidate CreateCandidate(CandidateDocument document, Guid? referralId)
    {
        ArgumentNullException.ThrowIfNull(document);
        
        return Candidate.Create(Id, referralId, Workflow.CreateCandidateWorkflow(), document);
    }
}