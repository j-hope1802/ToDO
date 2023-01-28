using Domain.Dtos;
using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Service;
using Microsoft.AspNetCore.Mvc;
namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController:ControllerBase
{
        private readonly UserService _UserService;

        public UserController(UserService userService)
        {
                _UserService = userService;
        }
        [HttpPost("Register")]
        public async Task<Response<AddUserDto>> Register(AddUserDto user)
        {
            
                 return await  _UserService.Register(user);
        }
    [HttpPost("Login")]
    public async Task<Response<GetUserDto>> GetLogin(int mobilenumber,string password)
    {

        return await _UserService.Login(mobilenumber,password);
    }
}