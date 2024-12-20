﻿using LibraryCRM.Application.Books.Commands.CreateBook;
using LibraryCRM.Application.Books.Commands.DeleteBook;
using LibraryCRM.Application.Books.Commands.UpdateBook;
using LibraryCRM.Application.Books.DTOs;
using LibraryCRM.Application.Books.Queries.GetAllBooks;
using LibraryCRM.Application.Books.Queries.GetBookById;
using LibraryCRM.Domain.Constants;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryCRM.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class BookController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    [AllowAnonymous]
    public async Task<ActionResult<IEnumerable<BookDTO>>> GetBooks()
    {
        var books = await mediator.Send(new GetAllBooksQuery());
        return Ok(books);
    }

    [HttpGet("{bookId}")]
    public async Task<ActionResult<BookDTO>> GetBook([FromRoute] Guid bookId)
    {
        var book = await mediator.Send(new GetBookByIdQuery(bookId));

        return Ok(book);
    }

    [HttpPost]
    [Authorize(Roles = UserRoles.Owner)]
    public async Task<ActionResult<BookDTO>> CreateBook([FromBody] CreateBookCommand command)
    {
        //check if library and author exists

        var createdBookId = await mediator.Send(command);
        var createdBook = await mediator.Send(new GetBookByIdQuery(createdBookId));

        return Ok(createdBook);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateBook([FromBody] UpdateBookCommand command)
    {
        //check if library and author exists

        await mediator.Send(command);

        var updatedBook = await mediator.Send(new GetBookByIdQuery(command.Id));

        return Ok(updatedBook);
    }

    [HttpDelete("{bookId}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteBook([FromRoute] Guid bookId)
    {
        await mediator.Send(new DeleteBookCommand(bookId));

        return Ok();
    }
}