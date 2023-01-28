using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos;
public class GetCommentDto{
   public int Id{get;set;}
    public int UserId{get;set;}
    public  string Description { get; set; }
    public int TodoId{get;set;}
    public string TodoName{get;set;}
    
}