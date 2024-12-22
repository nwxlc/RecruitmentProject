using AutoFixture;
using RecruitmentProject.Domain.Candidates;

namespace RecruitmentProject.TestDomain.Extensions;

public static class FixtureExtensions
{
    public static void ExecuteAllCustomizations(this IFixture fixture)
    {
        fixture.Customize<Candidate>(x =>
            x.FromFactory(() =>
                Candidate.Create(Guid.NewGuid(), Guid.NewGuid(), fixture.Create<CandidateWorkflow>(), fixture.Create<CandidateDocument>())));
    }
}