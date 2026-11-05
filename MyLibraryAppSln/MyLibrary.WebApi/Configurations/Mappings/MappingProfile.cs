using AutoMapper;
using MyLibrary.WebApi.DTOs.Request;
using MyLibrary.WebApi.DTOs.Response;
using MyLibrary.WebApi.Models;

namespace MyLibrary.WebApi.Configurations.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<UpdateUserRequestDTO, User>();
        CreateMap<User, UserResponseDTO>()
            .ForMember(
                dest => dest.UserName,
                opt => opt.MapFrom(
                    src => src.AspNetUser != null ?
                    src.AspNetUser.UserName : string.Empty));

        CreateMap<AuthorRequestDTO, Author>();
        CreateMap<Author, AuthorResponseDTO>();

        CreateMap<CategoryRequestDTO, Category>();
        CreateMap<Category, CategoryResponseDTO>();

        CreateMap<CopyRequestDTO, Copy>();
        CreateMap<Copy, CopyResponseDTO>()
            .ForMember(
                dest => dest.BookId,
                    opt => opt.MapFrom(
                        src => src.Book.Id))
            .ForMember(
                dest => dest.BookTitle,
                    opt => opt.MapFrom(
                        src => src.Book.Title));
    }
}
