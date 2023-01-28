using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;
public class Comment{
    public int Id{get;set;}
    public int UserId{get;set;}
    public  string Description { get; set; }
    public int TodoId{get;set;}
    public Todo Todo{get;set;}
    public User Users{get;set;}
}