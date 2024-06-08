using FluentValidation;
using LibraryCRM.Application.Books.DTOs;

namespace LibraryCRM.Application.Books.Validators;

public class CreateBookDTOValidator : AbstractValidator<CreateBookDTO>
{
    public CreateBookDTOValidator()
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