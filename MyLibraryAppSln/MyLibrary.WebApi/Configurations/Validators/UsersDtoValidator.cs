using FluentValidation;
using MyLibrary.WebApi.DTOs.Request;

namespace MyLibrary.WebApi.Configurations.Validators;

public class UsersDtoValidator : AbstractValidator<UpdateUserRequestDTO>
{
    public UsersDtoValidator()
    {
        RuleFor(dto => dto.FirstName).NotEmpty().MaximumLength(60);
        RuleFor(dto => dto.LastName).NotEmpty().MaximumLength(60);
    }
}
