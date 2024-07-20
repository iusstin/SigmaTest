using ApplicationCore.Candidates.Commands;
using Domain;
using Domain.Models;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SigmaTest.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CandidatesController : ControllerBase
{
	private readonly IMediator _mediator;
	private readonly IValidator<UpsertCandidateCmd> _validator;

    public CandidatesController(IMediator mediator, IValidator<UpsertCandidateCmd> validator)
    {
        _mediator = mediator;
        _validator = validator;
    }

    [HttpPost]
    public async Task<ActionResult<Candidate>> UpsertCandidate([FromBody] CreateCandidateModel candidate, CancellationToken cancellationToken)
    {
		var cmd = new UpsertCandidateCmd { model = candidate };
		var validation = _validator.Validate(cmd);
		if (!validation.IsValid)
		{
			return BadRequest(validation.ToString());
		}

        var result = await _mediator.Send(cmd, cancellationToken);
		return Ok(result);
    }
}
