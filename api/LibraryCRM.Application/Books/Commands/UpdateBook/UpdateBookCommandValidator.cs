using FluentValidation;
using LibraryCRM.Application.Books.Commands.CreateBook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCRM.Application.Books.Commands.UpdateBook;

public class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand>
{
    public UpdateBookCommandValidator()
    {
        RuleFor(x => x.Name)
           .NotEmpty()
           .Length(3, 50);

        RuleFor(x => x.Category)
            .NotEmpty()
            .Length(3, 30);

        RuleFor(x => x.AuthorId)
            .NotEmpty();

        RuleFor(x => x.LibraryId)
            .NotEmpty();
    }
}