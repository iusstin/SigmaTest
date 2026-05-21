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
public class CandidatesController(IMediator mediator, ILogger<CandidatesController> logger) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Candidate>>> GetAllCandidates(CancellationToken cancellationToken = default)
    {
        var result = await mediator.Send(new GetAllCandidatesQuery(), cancellationToken);

        logger.LogInformation("Something changed here ");
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
            logger.LogInformation($"Validation failed {validationResult.ToString()}");
            return BadRequest(validationResult.ToString("\n"));
		}

        var result = await mediator.Send(cmd, cancellationToken);
		return Ok(result);
    }
}
