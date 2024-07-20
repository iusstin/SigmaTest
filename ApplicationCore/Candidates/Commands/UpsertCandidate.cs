using ApplicationCore.BaseClasses;
using Domain;
using Domain.Interfaces;
using Domain.Models;
using MediatR;

namespace ApplicationCore.Candidates.Commands;

public class UpsertCandidateCmd : BaseCommand<Candidate>
{
    public CreateCandidateModel model { get; set; }
}

public class UpsertCandidateCmdHandler : BaseCommandHandler<UpsertCandidateCmd, Candidate>
{
    private readonly ICandidateRepository _candidateRepository;

    public UpsertCandidateCmdHandler(IMediator mediator, ICandidateRepository candidateRepository) 
        : base(mediator)
    {
        _candidateRepository = candidateRepository;
    }

    public override async Task<Candidate> Handle(UpsertCandidateCmd cmd, CancellationToken cancellationToken)
    {
        var existingCandidate = await _candidateRepository.GetByEmail(cmd.model.Email);
        if (existingCandidate is null)
        {
            var newCandidate = new Candidate()
            {
                Email = cmd.model.Email,
                FirstName = cmd.model.FirstName,
                LastName = cmd.model.LastName,
                PhoneNumber = cmd.model.PhoneNumber,
                LinkedInProfile = cmd.model.LinkedInProfile,
                GitHubProfile = cmd.model.GitHubProfile,
                StartCallTimeInterval = cmd.model.StartCallTimeInterval,
                EndCallTimeIntervall = cmd.model.EndCallTimeInterval,
                Comment = cmd.model.Comment,
            };

            await _candidateRepository.CreateCandidate(newCandidate, cancellationToken);
            return newCandidate;
        }

        existingCandidate.FirstName = cmd.model.FirstName ?? existingCandidate.FirstName;
        existingCandidate.LastName = cmd.model.LastName ?? existingCandidate.LastName;
        existingCandidate.PhoneNumber = cmd.model.PhoneNumber ?? existingCandidate.PhoneNumber;
        existingCandidate.LinkedInProfile = cmd.model.LinkedInProfile ?? existingCandidate.LinkedInProfile;
        existingCandidate.GitHubProfile = cmd.model.GitHubProfile ?? existingCandidate.GitHubProfile;
        existingCandidate.Comment = cmd.model.Comment ?? existingCandidate.Comment;
        existingCandidate.StartCallTimeInterval = cmd.model.StartCallTimeInterval ?? existingCandidate.StartCallTimeInterval;
        existingCandidate.EndCallTimeIntervall = cmd.model.EndCallTimeInterval ?? existingCandidate.EndCallTimeIntervall;

        await _candidateRepository.UpdateCandidate(existingCandidate, cancellationToken);
        return existingCandidate;
    }
}
