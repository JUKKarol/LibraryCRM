using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LibraryCRM.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LibraryController : ControllerBase
{
    private readonly IMediator _mediator;

    public LibraryController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<LibraryDTO>>> GetLibraries()
    {
        var libraries = await _mediator.Send(new GetAllLibrariesQuery());
        return Ok(libraries);
    }

    [HttpGet("{libraryId}")]
    public async Task<ActionResult<LibraryDTO>> GetLibrary([FromRoute] Guid libraryId)
    {
        var library = await _mediator.Send(new GetLibraryByIdQuery(libraryId));
        if (library == null)
        {
            return NotFound();
        }
        return Ok(library);
    }

    [HttpPost]
    public async Task<ActionResult<LibraryDTO>> CreateLibrary([FromBody] CreateLibraryCommand command)
    {
        var createdLibraryId = await _mediator.Send(command);
        var createdLibrary = await _mediator.Send(new GetLibraryByIdQuery(createdLibraryId));
        return CreatedAtAction(nameof(GetLibrary), new { libraryId = createdLibraryId }, createdLibrary);
    }

    [HttpPut("{libraryId}")]
    public async Task<ActionResult<LibraryDTO>> UpdateLibrary([FromRoute] Guid libraryId, [FromBody] UpdateLibraryCommand command)
    {
        command.Id = libraryId;
        await _mediator.Send(command);
        var updatedLibrary = await _mediator.Send(new GetLibraryByIdQuery(libraryId));
        if (updatedLibrary == null)
        {
            return NotFound();
        }
        return Ok(updatedLibrary);
    }

    [HttpDelete("{libraryId}")]
    public async Task<IActionResult> DeleteLibrary([FromRoute] Guid libraryId)
    {
        await _mediator.Send(new DeleteLibraryCommand(libraryId));
        return NoContent();
    }
}