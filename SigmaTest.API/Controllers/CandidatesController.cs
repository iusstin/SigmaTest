using ApplicationCore;
using ApplicationCore.Candidates.Commands;
using ApplicationCore.Candidates.Queries;
using Domain;
using Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SigmaTest.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CandidatesController(IMediator mediator) : ControllerBase
{

  [HttpGet]
    public async Task<ActionResult<IEnumerable<Candidate>>> GetAllCandidates(CancellationToken cancellationToken = default)
    {
        var result = await mediator.Send(new GetAllCandidatesQuery(), cancellationToken);
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<Candidate>> UpsertCandidate([FromBody] CreateCandidateModel candidate, CancellationToken cancellationToken = default)
    {
		var cmd = new UpsertCandidateCmd { model = candidate };
        UpsertCandidateValidator validator = new();
        var validationResult = validator.Validate(cmd);
        if (!validationResult.IsValid)
		{
            return BadRequest(validationResult.ToString("\n"));
		}

        var result = await mediator.Send(cmd, cancellationToken);
		return Ok(result);
    }

    [HttpGet("test")]
    public ActionResult<string> Test()
    {
        return Ok("API is working!");
    }
}
