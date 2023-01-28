using Infrastructure.Context;
using Domain.Dtos;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Infrastructure.MapperProfiles;
using AutoMapper;
using Domain.Wrapper;
using System.Net;
namespace Infrastructure.Service;
public class CommentService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;
    public CommentService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<Response<List<GetCommentDto>>> GetComments()
    {
        try
        {
            var result = await _context.Comments.ToListAsync();
            var mapped = _mapper.Map<List<GetCommentDto>>(result);
            return new Response<List<GetCommentDto>>(mapped);
        }
        catch (Exception ex)
        {

            return new Response<List<GetCommentDto>>(HttpStatusCode.InternalServerError, new List<string>() { ex.Message });
        }
    }
    public async Task<Response<AddComentDto>> AddComments(AddComentDto com)
    {
        try
        {
            var mapped = _mapper.Map<Comment>(com);
            _context.Comments.Add(mapped);
            await _context.SaveChangesAsync();
            com.Id=mapped.Id;
          
            return new Response<AddComentDto>(com);
        }
        catch (Exception ex)
        {
            return new Response<AddComentDto>(HttpStatusCode.InternalServerError, new List<string>() { ex.Message });
        }
    }
    public async Task<Response<AddComentDto>> UpdateComment(AddComentDto com)
    {
             try
        {
          var result = await _context.Todos.FindAsync(com.Id);
          var mapped = _mapper.Map<AddComentDto>(result);
            return new Response<AddComentDto>(mapped);
        }
        catch (Exception ex)
        {
         return new Response<AddComentDto>(HttpStatusCode.InternalServerError,new List<string>{ex.Message});
        }
        }
    public async Task<Response<GetCommentDto>> GetCommentById(int id)
    {
        try
        {
            var result = await _context.Comments.FindAsync(id);
          var mapped = _mapper.Map<GetCommentDto>(result);
            return new Response<GetCommentDto>(mapped);
        }
        catch (Exception ex)
        {
         return new Response<GetCommentDto>(HttpStatusCode.InternalServerError,new List<string>{ex.Message});
        }
    }
    public async Task<Response<string>>DeleteComment(int id)
    {
        var find = await _context.Comments.FindAsync(id);
        if(find==null) return new Response<string>(HttpStatusCode.NotFound,new List<string>{"Not found"});
        _context.Comments.Remove(find);
        _context.SaveChangesAsync();
        return new Response<string>("Sucessfully");
    }
}