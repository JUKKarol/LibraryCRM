using AutoMapper;
using LibraryCRM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCRM.Application.Books.DTOs;
internal class BooksProfile : Profile
{
    public BooksProfile()
    {
        CreateMap<Book, BookDTO>()
            .ForMember(d => d.AuthorName, opt =>
                opt.MapFrom(src => src.Author.Name))
            .ForMember(d => d.LibraryName, opt =>
                opt.MapFrom(src => src.Library.Name));
    }
}
