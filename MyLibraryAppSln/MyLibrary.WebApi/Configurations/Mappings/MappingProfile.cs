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

        CreateMap<ReservationRequestDTO, Reservation>();
        CreateMap<Reservation, ReservationResponseDTO>()
            .ForMember(
                dest => dest.BookId,
                    opt => opt.MapFrom(
                        src => src.Book.Id))
            .ForMember(
                dest => dest.BookTitle,
                    opt => opt.MapFrom(
                        src => src.Book.Title))
            .ForMember(
                dest => dest.UserId,
                    opt => opt.MapFrom(
                        src => src.User.Id))
            .ForMember(
                dest => dest.UserFullName,
                    opt => opt.MapFrom(
                        src => src.User.FirstName + " " + src.User.LastName));

        CreateMap<LoanRequestDTO, Loan>();
        CreateMap<Loan, LoanResponseDTO>()
            .ForMember(
                dest => dest.CopyId,
                opt => opt.MapFrom(
                    src => src.Copy.Id))
            .ForMember(
                dest => dest.BookId,
                    opt => opt.MapFrom(
                        src => src.Copy.BookId))
            .ForMember(
                dest => dest.BookTitle,
                    opt => opt.MapFrom(
                        src => src.Copy.Book.Title))
            .ForMember(
                dest => dest.UserId,
                    opt => opt.MapFrom(
                        src => src.User.Id))
            .ForMember(
                dest => dest.UserFullName,
                    opt => opt.MapFrom(
                        src => src.User.FirstName + " " + src.User.LastName))
            .ForMember(
                dest => dest.FineId,
                opt => opt.MapFrom(
                    src => src.Fines.FirstOrDefault() != null ?
                    src.Fines.FirstOrDefault()!.Id : 0))
            .ForMember(
                dest => dest.FineAmount,
                opt => opt.MapFrom(
                    src => src.Fines.FirstOrDefault() != null ?
                    src.Fines.FirstOrDefault()!.Amount : 0m));

        CreateMap<FineRequestDTO, Fine>();
        CreateMap<Fine, FineResponseDTO>()
            .ForMember(
                dest => dest.UserId,
                    opt => opt.MapFrom(
                        src => src.User.Id))
            .ForMember(
                dest => dest.UserFullName,
                    opt => opt.MapFrom(
                        src => src.User.FirstName + " " + src.User.LastName));
    }
}
