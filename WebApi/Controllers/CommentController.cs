using Domain.Dtos;
using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Service;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CommentController:ControllerBase
{
        private readonly CommentService _CommentService;

        public CommentController(CommentService CommentService)
        {
                _CommentService = CommentService;
        }

        [HttpGet()]
        public  async Task<Response<List<GetCommentDto>>> GetComments()
        {
                return await _CommentService.GetComments();
        }
        
        [HttpGet("GetBYID")]
        public  async Task<Response<GetCommentDto>>GetById(int id){
            return await _CommentService.GetCommentById(id);
        }
        
        [HttpPost]
        public async Task<Response<AddComentDto>> AddComment(AddComentDto com)
        {
            
                 return await  _CommentService.AddComments(com);
        }
          
        [HttpPut]
        public async Task<Response<AddComentDto>>UpdateComment(AddComentDto com)
        {
            {
        if (ModelState.IsValid)
        { 
            return await _CommentService.AddComments(com);
        }
        else
        {
            
            var errors = ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage).ToList();
            return new Response<AddComentDto>(System.Net.HttpStatusCode.NotFound, errors);
        }
       
    }
        }
        [HttpDelete]
        public async Task <Response<string>>DeleteComment (int id)
        {
           return await _CommentService.DeleteComment(id);
        } 
}