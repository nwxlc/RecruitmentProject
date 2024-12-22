namespace RecruitmentProject.Domain;

public class Candidate
{
    private Candidate(Guid id,
        Guid? vacancyId, 
        Guid? referralId, 
        CandidateWorkflow workflow, 
        CandidateDocument document)
    {
        Id = id;
        VacancyId = vacancyId;
        ReferralId = referralId;
        Workflow = workflow;
        Document = document;
    }

    public Guid Id { get; private init; }
    public Guid? VacancyId { get; private set; }
    public Guid? ReferralId { get; private set; }
    public CandidateWorkflow Workflow { get; private set; }
    public CandidateDocument Document { get; private set; }

    public static Candidate Create(Guid vacancyId, Guid? referralId, CandidateWorkflow workflow,
        CandidateDocument document)
    {
        ArgumentNullException.ThrowIfNull(workflow);
        ArgumentNullException.ThrowIfNull(document);

        return new Candidate(Guid.NewGuid(), vacancyId, referralId, workflow, document);
    }
    
    public void Approve(Employee employee, string comment)
    {
        ArgumentNullException.ThrowIfNull(employee);
        ArgumentException.ThrowIfNullOrWhiteSpace(comment);
        
        Workflow.Approve(employee, comment);
    }

    public void Reject(Employee employee, string comment)
    {
        ArgumentNullException.ThrowIfNull(employee);
        ArgumentException.ThrowIfNullOrWhiteSpace(comment);
        
        Workflow.Reject(employee, comment);
    }

    public void Restart()
    {
        Workflow.Restart();
    }
}