using Azure.Core;
using ConferenceMicroservice.API.Contracts;
using ConferenceMicroservice.Core.Interfaces;
using ConferenceMicroservice.Core.Models;
using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ConferenceMicroservice.API.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUsersService usersService;

    public UsersController(IUsersService usersService)
    {
        this.usersService = usersService;
    }

    [HttpGet("{id:guid}/conferences")]
    public async Task<ActionResult<List<Conference>>> GetConferences(Guid id)
    {
        var conferences = await usersService.GetUserConferences(id);

        var response = conferences.Select(c => new ConferencesResponse(c.Id, c.Title, c.Descriptoin, c.DateTimeStart, c.DateTimeEnd));

        return Ok(response);
    }

    [HttpPost("{userId:guid}/conferences/{conferenceId:guid}")]
    public async Task<ActionResult> AddUserToConference(Guid userId, Guid conferenceId)
    {
        await usersService.AddUserToConference(userId, conferenceId);

        return Ok(conferenceId);
    }

    [HttpDelete("{userId:guid}/conferences/{conferenceId:guid}")]
    public async Task<ActionResult> DeleteFromConference(Guid userId, Guid conferenceId)
    {
        await usersService.RemoveConferenceFromUser(userId, conferenceId);

        return Ok();
    }

    [HttpGet]
    public async Task<ActionResult<List<UsersResponse>>> GetUsers()
    {
        var users = await usersService.GetAllUsers();

        var response = users.Select(u => new UsersResponse(u.Id, u.Email, u.FirstName, u.SecondName, u.ThirdName, u.PhoneNumber));

        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> CreateUser([FromBody] UsersRequest request)
    {
        var user = Core.Models.User.Create(
            Guid.NewGuid(),
            request.Email,
            request.PasswordHash,
            request.FirstName,
            request.SecondName,
            request.ThirdName,
            request.PhoneNumber);

        if (user.IsFailure)
        {
            return BadRequest(user.Error);
        }

        var userId = await usersService.CreateUser(user.Value);
        return Ok(userId);
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult<Guid>> UpdateUser(Guid id, [FromBody] UsersRequest request)
    {
        var userId = await usersService.UpdateUser(id, request.Email, request.PasswordHash, request.FirstName, request.SecondName, request.ThirdName, request.PhoneNumber);

        return Ok(userId);
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<Guid>> DeleteUser(Guid id)
    {
        return Ok(await usersService.DeleteUser(id));
    }
}
