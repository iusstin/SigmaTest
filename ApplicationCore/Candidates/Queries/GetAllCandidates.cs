using ApplicationCore.BaseClasses;
using Domain;
using Domain.Interfaces;
using MediatR;

namespace ApplicationCore.Candidates.Queries;

public class GetAllCandidatesQuery : BaseQuery<IEnumerable<Candidate>>
{ }

public class GetAllCandidatesQueryHandler : BaseQueryHandler<GetAllCandidatesQuery, IEnumerable<Candidate>>
{
    private readonly ICandidateRepository _candidateRepository;

    public GetAllCandidatesQueryHandler(IMediator mediator, ICandidateRepository candidateRepository) 
        : base(mediator)
    {
        _candidateRepository = candidateRepository;
    }

    public override async Task<IEnumerable<Candidate>> Handle(GetAllCandidatesQuery cmd, CancellationToken cancellationToken)
    {
        var candidates = await _candidateRepository.GetAll(cancellationToken);
        return candidates ?? Enumerable.Empty<Candidate>();
    }
}
