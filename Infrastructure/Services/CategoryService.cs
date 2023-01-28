using Infrastructure.Context;
using Domain.Dtos;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Infrastructure.MapperProfiles;
using AutoMapper;
using Domain.Wrapper;
using System.Net;
namespace Infrastructure.Service;
public class CategoryService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;
    public CategoryService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<Response<List<GetCategoryDto>>> GetCategory()
    {
        try
        {
            var result = await _context.Categories.ToListAsync();
            var mapped = _mapper.Map<List<GetCategoryDto>>(result);
            return new Response<List<GetCategoryDto>>(mapped);
        }
        catch (Exception ex)
        {

            return new Response<List<GetCategoryDto>>(HttpStatusCode.InternalServerError, new List<string>() { ex.Message });
        }
    }
    public async Task<Response<AddCategoryDto>> AddCategory(AddCategoryDto cat)
    {
        try
        {
            var mapped = _mapper.Map<Category>(cat);
            _context.Categories.Add(mapped);
            await _context.SaveChangesAsync();
            cat.Id=mapped.Id;
          
            return new Response<AddCategoryDto>(cat);
        }
        catch (Exception ex)
        {
            return new Response<AddCategoryDto>(HttpStatusCode.InternalServerError, new List<string>() { ex.Message });
        }
    }
    public async Task<Response<AddCategoryDto>> UpdateCategory(AddCategoryDto cat)
    {
             try
        {
          var result = await _context.Categories.FindAsync(cat.Id);
          var mapped = _mapper.Map<AddCategoryDto>(result);
            return new Response<AddCategoryDto>(mapped);
        }
        catch (Exception ex)
        {
         return new Response<AddCategoryDto>(HttpStatusCode.InternalServerError,new List<string>{ex.Message});
        }
        }
    public async Task<Response<GetCategoryDto>> GetCategoryById(int id)
    {
        try
        {
            var result = await _context.Categories.FindAsync(id);
          var mapped = _mapper.Map<GetCategoryDto>(result);
            return new Response<GetCategoryDto>(mapped);
        }
        catch (Exception ex)
        {
         return new Response<GetCategoryDto>(HttpStatusCode.InternalServerError,new List<string>{ex.Message});
        }
    }
    public async Task<Response<string>>DeleteCategory(int id)
    {
        var find = await _context.Categories.FindAsync(id);
        if(find==null) return new Response<string>(HttpStatusCode.NotFound,new List<string>{"Not found"});
        _context.Categories.Remove(find);
        _context.SaveChangesAsync();
        return new Response<string>("Sucessfully");
    }
}