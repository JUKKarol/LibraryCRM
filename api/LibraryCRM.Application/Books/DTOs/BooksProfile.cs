using AutoMapper;
using LibraryCRM.Application.Books.Commands.CreateBook;
using LibraryCRM.Application.Books.Commands.UpdateBook;
using LibraryCRM.Domain.Entities;

namespace LibraryCRM.Application.Books.DTOs;

internal class BooksProfile : Profile
{
    public BooksProfile()
    {
        CreateMap<CreateBookCommand, Book>();
        CreateMap<UpdateBookCommand, Book>();

        CreateMap<Book, BookDTO>()
            .ForMember(d => d.AuthorName, opt =>
                opt.MapFrom(src => src.Author.Name))
            .ForMember(d => d.LibraryName, opt =>
                opt.MapFrom(src => src.Library.Name));
    }
}