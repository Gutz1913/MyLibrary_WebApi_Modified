using FluentValidation;
using MyLibrary.WebApi.DTOs.Request;

namespace MyLibrary.WebApi.Configurations.Validators;

public class PublishersDtoValidator : AbstractValidator<PublisherRequestDTO>
{
    public PublishersDtoValidator()
    {
        RuleFor(dto => dto.Name).NotEmpty().MaximumLength(100);
        RuleFor(dto => dto.Country).NotEmpty().MaximumLength(50);
        RuleFor(dto => dto.WebSite).NotEmpty().MaximumLength(200);
        RuleFor(dto => dto.Email).NotEmpty().MaximumLength(150);
        RuleFor(dto => dto.PhoneNumber).MaximumLength(50);
    }
}
