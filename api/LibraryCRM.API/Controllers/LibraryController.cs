using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LibraryCRM.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LibraryController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<LibraryDTO>>> GetLibraries()
    {
        var libraries = await mediator.Send(new GetAllLibrariesQuery());
        return Ok(libraries);
    }

    [HttpGet("{libraryId}")]
    public async Task<ActionResult<LibraryDTO>> GetLibrary([FromRoute] Guid libraryId)
    {
        var library = await mediator.Send(new GetLibraryByIdQuery(libraryId));
    }
}