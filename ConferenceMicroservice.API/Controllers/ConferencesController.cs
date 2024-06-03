using ConferenceMicroservice.API.Contracts;
using ConferenceMicroservice.Application.Services;
using ConferenceMicroservice.Core.Interfaces;
using ConferenceMicroservice.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace ConferenceMicroservice.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ConferencesController : ControllerBase
{
    private readonly IConferencesService conferencesService;

    public ConferencesController(IConferencesService conferencesService)
    {
        this.conferencesService = conferencesService;
    }

    [HttpGet]
    public async Task<ActionResult<List<ConferencesResponse>>> GetConferences()
    {
        var conferences = await conferencesService.GetAllConferences();

        var response = conferences.Select(c => new ConferencesResponse(c.Id, c.Title, c.Descriptoin, c.DateTimeEnd, c.DateTimeStart));

        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> CreateConference([FromBody] ConferencesRequest request)
    {
        var conference = Core.Models.Conference.Create(
            Guid.NewGuid(),
            request.Title,
            request.Description,
            request.DateTimeStart,
            request.DateTimeEnd);

        if(conference.IsFailure)
        {
            return BadRequest(conference.Error);
        }

        var conferenceId = await conferencesService.CreateConference(conference.Value);
        return Ok(conferenceId);
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult<Guid>> UpdateConference(Guid id, [FromBody] ConferencesRequest request)
    {
        var conferenceId = await conferencesService.UpdateConference(id, request.Title, request.Description, request.DateTimeStart, request.DateTimeEnd);

        return Ok(conferenceId);
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<Guid>> DeleteConference(Guid id)
    {
        return Ok(await conferencesService.DeleteConference(id));
    }

    [HttpGet("{id:guid}/users")]
    public async Task<ActionResult<List<User>>> GetUsers(Guid id)
    {
        var users = await conferencesService.GetConferenceUsers(id);

        var response = users.Select(u => new UsersResponse(u.Id, u.Email, u.FirstName, u.SecondName, u.ThirdName, u.PhoneNumber));

        return Ok(response);
    }

    [HttpPost("{userId:guid}/users/{conferenceId:guid}")]
    public async Task<ActionResult> AddConferenceToUser(Guid conferenceId, Guid userId)
    {
        var userid = await conferencesService.AddConferenceToUser(conferenceId, userId);

        return Ok(userid);
    }

    [HttpDelete("{userId:guid}/users/{conferenceId:guid}")]
    public async Task<ActionResult<Guid>> RemoveUserFromConference(Guid conferenceId, Guid userId)
    {
        var userid = await conferencesService.RemoveUserFromConference(conferenceId, userId);

        return Ok(userid);
    }
}
