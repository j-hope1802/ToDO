using Infrastructure.Context;
using Domain.Dtos;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Infrastructure.MapperProfiles;
using AutoMapper;
using Domain.Wrapper;
using System.Net;
namespace Infrastructure.Service;
public class ToDoService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;
    public ToDoService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<Response<List<GetToDoDto>>> GetTodos()
    {
        try
        {
            var result = await _context.Todos.ToListAsync();
            var mapped = _mapper.Map<List<GetToDoDto>>(result);
            return new Response<List<GetToDoDto>>(mapped);
        }
        catch (Exception ex)
        {

            return new Response<List<GetToDoDto>>(HttpStatusCode.InternalServerError, new List<string>() { ex.Message });
        }
    }
    public async Task<Response<AddToDoDto>> AddTodo(AddToDoDto todo)
    {
        try
        {
            var mapped = _mapper.Map<Todo>(todo);
            _context.Todos.Add(mapped);
            await _context.SaveChangesAsync();
            todo.Id=mapped.Id;
          
            return new Response<AddToDoDto>(todo);
        }
        catch (Exception ex)
        {
            return new Response<AddToDoDto>(HttpStatusCode.InternalServerError, new List<string>() { ex.Message });
        }
    }
    public async Task<Response<AddToDoDto>> UpdateTodos(AddToDoDto todo)
    {
             try
        {
          var result = await _context.Todos.FindAsync(todo.Id);
          var mapped = _mapper.Map<AddToDoDto>(result);
          result.Update=todo.Update;
            return new Response<AddToDoDto>(mapped);
        }
        catch (Exception ex)
        {
         return new Response<AddToDoDto>(HttpStatusCode.InternalServerError,new List<string>{ex.Message});
        }
        }
    public async Task<Response<GetToDoDto>> GetToDoById(int id)
    {
        try
        {
            var result = await _context.Todos.FindAsync(id);
          var mapped = _mapper.Map<GetToDoDto>(result);
            return new Response<GetToDoDto>(mapped);
        }
        catch (Exception ex)
        {
         return new Response<GetToDoDto>(HttpStatusCode.InternalServerError,new List<string>{ex.Message});
        }
    }
    public async Task<Response<string>>DeleteTodo(int id)
    {
        var find = await _context.Todos.FindAsync(id);
        if(find==null) return new Response<string>(HttpStatusCode.NotFound,new List<string>{"Not found"});
        _context.Todos.Remove(find);
        _context.SaveChangesAsync();
        return new Response<string>("Sucessfully");
    }
}