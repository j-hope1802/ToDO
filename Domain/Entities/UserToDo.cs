namespace Domain.Entities;
public class UserTodo{
    public int UserId{get;set;}
    public User Users{get;set;}
    public int TodoId{get;set;}
    public Todo Todos{get;set;}
}