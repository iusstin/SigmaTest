using ApplicationCore.BaseClasses;
using Domain;
using Domain.Interfaces;
using Domain.Models;
using MediatR;
using System.Runtime.Serialization;

namespace ApplicationCore.Candidates.Commands;

[DataContract]
public class UpsertCandidateCmd : BaseCommand<Candidate>
{
    [DataMember]
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

        existingCandidate.FirstName = cmd.model.FirstName;
        existingCandidate.LastName = cmd.model.LastName;
        existingCandidate.PhoneNumber = cmd.model.PhoneNumber;
        existingCandidate.LinkedInProfile = cmd.model.LinkedInProfile;
        existingCandidate.GitHubProfile = cmd.model.GitHubProfile;
        existingCandidate.Comment = cmd.model.Comment;
        existingCandidate.StartCallTimeInterval = cmd.model.StartCallTimeInterval;
        existingCandidate.EndCallTimeIntervall = cmd.model.EndCallTimeInterval;

        await _candidateRepository.UpdateCandidate(existingCandidate, cancellationToken);
        return existingCandidate;
    }
}
