using ApplicationCore;
using ApplicationCore.Candidates.Commands;
using Domain;
using Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using SigmaTest.API.Controllers;

namespace SigmaTestTask.Tests;

public class CandidatesControllerTests
{
    private readonly Mock<IMediator> _mockMediator;
    private readonly CandidatesController _controller;

    public CandidatesControllerTests()
    {
        _mockMediator = new Mock<IMediator>();
        _controller = new CandidatesController(_mockMediator.Object);
    }

    [Fact]
    public async Task UpsertCandidateReturnsOk()
    {
        var model = new CreateCandidateModel(
            "Iustin",
            "Deaconu",
            "iustindeaconu@yahoo.com",
            "junior .net developer",
            "123456",
            DateTime.Now,
            DateTime.Now.AddDays(7),
            "linkedin.com/iustin-deaconu",
            "github.com/iusstin");

        var cmd = new UpsertCandidateCmd { model = model };
        _mockMediator.Setup(m => m.Send(It.IsAny<UpsertCandidateCmd>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new Candidate 
            { 
                Email = "iustindeaconu@yahoo.com",
                FirstName = "Iustin",
                LastName = "Deaconu",
                Comment = "junior .net developer",
                PhoneNumber = "123456",
                LinkedInProfile = "linkedin.com/iustin-deaconu",
                GitHubProfile = "github.com/iusstin"
            });

        var response = await _controller.UpsertCandidate(model);
        var result = Assert.IsType<OkObjectResult>(response.Result);
        var candidate = Assert.IsType<Candidate>(result.Value);
        Assert.Equal(model.Email, candidate.Email);
    }

    [Fact]
    public async Task UpsertCandidateReturnsBadRequest()
    {
        var model = new CreateCandidateModel(Email: "harrypotter@mail.io");
        var cmd = new UpsertCandidateCmd { model = model };
        var validator = new UpsertCandidateValidator();

        var response = await _controller.UpsertCandidate(model);
        var result = Assert.IsType<BadRequestObjectResult>(response.Result);
        var validationResult = validator.Validate(cmd);
        Assert.Equal(validationResult.ToString("\n"), result.Value);
        
    }
}