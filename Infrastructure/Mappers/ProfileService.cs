namespace Infrastructure.Mappers;
using AutoMapper;
using Domain.Dtos;
using Domain.Entities;

public class ProfileService : Profile {
    public ProfileService(){
        CreateMap<GetActorDto, AddActorDto>().ReverseMap();
        CreateMap<GetActorDto, Actor>().ReverseMap();
        CreateMap<AddActorDto, Actor>().ReverseMap();
        CreateMap<GetMovieDto, AddMovieDto>().ReverseMap();
        CreateMap<GetMovieDto, Movie>().ReverseMap();
        CreateMap<AddMovieDto, Movie>().ReverseMap();
        CreateMap<GetCastDto, AddCastDto>().ReverseMap();
        CreateMap<GetCastDto, Cast>().ReverseMap();
        CreateMap<AddCastDto, Cast>().ReverseMap();
        CreateMap<GetCategoryDto, AddCategoryDto>().ReverseMap();
        CreateMap<GetCategoryDto, Category>().ReverseMap();
        CreateMap<AddCategoryDto, Category>().ReverseMap();
    }
}