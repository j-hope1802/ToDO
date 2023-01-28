using Domain.Dtos;
using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Service;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoryController:ControllerBase
{
        private readonly CategoryService _CategoryService;

        public CategoryController(CategoryService CategoryService)
        {
                _CategoryService = CategoryService;
        }

        [HttpGet()]
        public  async Task<Response<List<GetCategoryDto>>> GetCategory()
        {
                return await _CategoryService.GetCategory();
        }
        
        [HttpGet("GetBYID")]
        public  async Task<Response<GetCategoryDto>>GetById(int id){
            return await _CategoryService.GetCategoryById(id);
        }
        
        [HttpPost]
        public async Task<Response<AddCategoryDto>> AddCategory(AddCategoryDto cat)
        {
            
                 return await  _CategoryService.AddCategory(cat);
        }
          
        [HttpPut]
        public async Task<Response<AddCategoryDto>>UpdateCategory(AddCategoryDto cat)
        {
            {
        if (ModelState.IsValid)
        { 
            return await _CategoryService.AddCategory(cat);
        }
        else
        {
            
            var errors = ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage).ToList();
            return new Response<AddCategoryDto>(System.Net.HttpStatusCode.NotFound, errors);
        }
       
    }
        }
        [HttpDelete]
        public async Task <Response<string>>DeleteToDos (int id)
        {
           return await _CategoryService.DeleteCategory(id);
        } 
}