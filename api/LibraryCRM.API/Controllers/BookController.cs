using LibraryCRM.Application.Books.DTOs;
using LibraryCRM.Application.Books.Service.BookService;
using Microsoft.AspNetCore.Mvc;

namespace LibraryCRM.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BookController(IBookService bookService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetBooks()
    {
        var books = await bookService.GetBooks();
        return Ok(books);
    }

    [HttpGet("{bookId}")]
    public async Task<IActionResult> GetBook([FromRoute] Guid bookId)
    {
        var book = await bookService.GetBookById(bookId);

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
    public async Task<IActionResult> CreateBook([FromBody] CreateBookDTO book)
    {
        //check if library and author exists

        var createdBookId = await bookService.CreateBook(book);
        var createdBook = await bookService.GetBookById(createdBookId);

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