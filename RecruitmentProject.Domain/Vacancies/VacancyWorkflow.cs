using RecruitmentProject.Domain.Candidates;

namespace RecruitmentProject.Domain.Vacancies;

public class VacancyWorkflow
{
    private VacancyWorkflow(string name, IReadOnlyCollection<VacancyWorkflowStep> steps)
    {
        Name = name;
        Steps = steps;
    }

    public string Name { get; private set; }
    public IReadOnlyCollection< VacancyWorkflowStep> Steps { get; private set; }

    public static VacancyWorkflow Create(string name, IReadOnlyCollection<VacancyWorkflowStep> steps)
    {
        ArgumentNullException.ThrowIfNull(name);

        return new VacancyWorkflow(name, steps);
    }
    
    public CandidateWorkflow CreateCandidateWorkflow()
    {
        return CandidateWorkflow.Create(Steps.Select(steps => steps.CreateCandidateWorkflowStep()).ToList());
    }
}