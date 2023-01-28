using Infrastructure.Context;
using Domain.Dtos;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Infrastructure.MapperProfiles;
using AutoMapper;
using Domain.Wrapper;
using System.Net;

namespace Infrastructure.Service;
public class UserService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;
    public UserService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
  
    
    public async Task<Response<GetUserDto>> Login(int mobilenumber ,string password)
    {
        try
        {
            var result = await _context.Users.FirstOrDefaultAsync(x=>x.MobileNumber==mobilenumber && x.Password==password);
            if(result==null)
            return new Response<GetUserDto>(HttpStatusCode.BadRequest,new List<string>{"Not Found"});
          var mapped = _mapper.Map<GetUserDto>(result);
            return new Response<GetUserDto>(mapped);
        }
        catch (Exception ex)
        {
         return new Response<GetUserDto>(HttpStatusCode.NotFound,new List<string>{ex.Message});
        }

    }
     public async Task<Response<AddUserDto>> Register(AddUserDto user)
    {
     try
        {
            var mapped = _mapper.Map<User>(user);
            _context.Users.Add(mapped);
            await _context.SaveChangesAsync();
mapped.Id=user.Id; 
            return new Response<AddUserDto>(user);
        }
        catch (Exception ex)
        {
            return new Response<AddUserDto>(HttpStatusCode.InternalServerError, new List<string>() { ex.Message });
        }

    }
   
}