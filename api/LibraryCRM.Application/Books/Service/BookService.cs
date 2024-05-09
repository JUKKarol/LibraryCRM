using AutoMapper;
using LibraryCRM.Application.Books.DTOs;
using LibraryCRM.Domain.Entities;
using LibraryCRM.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace LibraryCRM.Application.Books.Service.BookService;

internal class BookService(IBookRepository bookRepository, IMapper mapper) : IBookService
{
    public async Task<IEnumerable<BookDTO>> GetBooks()
    {
        var books = await bookRepository.GetAllBooks();
        var booksDTO = mapper.Map<IEnumerable<BookDTO>>(books);

        return booksDTO;
    }

    public async Task<BookDTO> GetBookById(Guid bookId)
    {
        var book = await bookRepository.GetBookById(bookId);
        var bookDTO = mapper.Map<BookDTO>(book);

        return bookDTO;
    }

    public async Task<Guid> CreateBook(CreateBookDTO bookRequestDTO)
    {
        var book = mapper.Map<Book>(bookRequestDTO);
        var createdBookId = await bookRepository.CreateBook(book);

        return createdBookId;
    }
}