using LibraryCRM.Application.Books.Commands.CreateBook;
using LibraryCRM.Application.Books.DTOs;
using LibraryCRM.Application.Books.Queries.GetAllBooks;
using LibraryCRM.Application.Books.Queries.GetBookById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LibraryCRM.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BookController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetBooks()
    {
        var books = await mediator.Send(new GetAllBooksQuery());
        return Ok(books);
    }

    [HttpGet("{bookId}")]
    public async Task<IActionResult> GetBook([FromRoute] Guid id)
    {
        var book = await mediator.Send(new GetBookByIdQuery(id));

        if (book == null)
        {
            return NotFound();
        }
        else
        {
            return Ok(book);
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateBook([FromBody] CreateBookCommand command)
    {
        //check if library and author exists

        var createdBookId = await mediator.Send(command);
        var createdBook = await mediator.Send(new GetBookByIdQuery(createdBookId));

        return Ok(createdBook);
    }

    //[HttpPut("{id}")]
    //public async Task<IActionResult> UpdateBook(int id, Book book)
    //{
    //    var updatedBook = await bookService.UpdateBookAsync(id, book);
    //    return Ok(updatedBook);
    //}

    //[HttpDelete("{id}")]
    //public async Task<IActionResult> DeleteBook(int id)
    //{
    //    await bookService.DeleteBookAsync(id);
    //    return NoContent();
    //}
}