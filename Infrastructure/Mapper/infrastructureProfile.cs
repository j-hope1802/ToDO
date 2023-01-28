using AutoMapper;
using Domain.Dtos;
using Domain.Entities;
namespace Infrastructure.MapperProfiles;
 public class InfrastructureProfile:Profile
 {
    public InfrastructureProfile()
    {
        CreateMap<User,GetUserDto>().ReverseMap();
        CreateMap<AddUserDto,User>();
        CreateMap<Category,GetCategoryDto>().ReverseMap();
        CreateMap<AddCategoryDto,Category>();
        CreateMap<Comment,GetCommentDto>().ReverseMap();
        CreateMap<AddComentDto,Comment>();
        CreateMap<Todo,GetToDoDto>().ReverseMap();
        CreateMap<AddToDoDto,Todo>();
    }
 }