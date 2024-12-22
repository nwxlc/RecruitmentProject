namespace RecruitmentProject.Domain.Candidates;

public class CandidateDocument
{
    private CandidateDocument(string name, string workExperience)
    {
        Name = name;
        WorkExperience = workExperience;
    }
    
    public string Name { get; private set; }
    public string WorkExperience { get; private set; }

    public static CandidateDocument Create(string name, string workExperience)
    {
        ArgumentNullException.ThrowIfNull(name);
        ArgumentNullException.ThrowIfNull(workExperience);

        return new CandidateDocument(name, workExperience);
    }
}