using Domain.Dtos;
using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Service;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ToDoController:ControllerBase
{
        private readonly ToDoService _ToDoService;

        public ToDoController(ToDoService ToDoService)
        {
                _ToDoService = ToDoService;
        }

        [HttpGet()]
        public  async Task<Response<List<GetToDoDto>>> GetToDo()
        {
                return await _ToDoService.GetTodos();
        }
        
        [HttpGet("GetBYID")]
        public  async Task<Response<GetToDoDto>>GetById(int id){
            return await _ToDoService.GetToDoById(id);
        }
        
        [HttpPost]
        public async Task<Response<AddToDoDto>> AddToDO(AddToDoDto todo)
        {
            
                 return await  _ToDoService.AddTodo(todo);
        }
          
        [HttpPut]
        public async Task<Response<AddToDoDto>>UpdateToDo(AddToDoDto todo)
        {
            {
        if (ModelState.IsValid)
        { 
            return await _ToDoService.AddTodo(todo);
        }
        else
        {
            
            var errors = ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage).ToList();
            return new Response<AddToDoDto>(System.Net.HttpStatusCode.NotFound, errors);
        }
       
    }
        }
        [HttpDelete]
        public async Task <Response<string>>DeleteToDos (int id)
        {
           return await _ToDoService.DeleteTodo(id);
        } 
}